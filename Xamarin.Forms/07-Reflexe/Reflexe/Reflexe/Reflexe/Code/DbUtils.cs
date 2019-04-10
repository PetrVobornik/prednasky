using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

namespace Reflexe
{
    public static class DbUtils
    {
        public static SQLiteAsyncConnection DB { get; private set; }

        public static async Task Init()
        {
            DB = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "data.db"));
            foreach (var tbl in VsechnyDbTridy)
                await DB.CreateTableAsync(tbl);
        }

        static IList<Type> vsechnyDbTridy;
        public static IList<Type> VsechnyDbTridy
        {
            get
            {
                if (vsechnyDbTridy == null)
                    vsechnyDbTridy = typeof(DbUtils).Assembly.GetTypes()
                        .Where(t => t.IsDefined(typeof(TableAttribute))).ToList();
                return vsechnyDbTridy;
            }
        }

        private static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(()
            => new ResourceManager(typeof(AppResources)));

        public static string Popisek(MemberInfo mi)
        {
            string name = mi.GetCustomAttribute<PopisekAttribute>()?.Text;
            if (String.IsNullOrEmpty(name))
            {
                string key = mi.Name;
                if (mi.MemberType == MemberTypes.Property)
                    key = ((PropertyInfo)mi).DeclaringType.Name + "_" + key;
                name = ResMgr.Value.GetString("DB_" + key);
            }
            if (String.IsNullOrEmpty(name))
                name = mi.Name;
            return name;
        }

        public static async Task<IEnumerable> DataTabulky(Type trida)
        {
            //var result = await DB.Table<Osoba>().ToListAsync();
            var table = DB.GetType().GetMethod("Table").MakeGenericMethod(trida).Invoke(DB, new object[] { });
            var task = (Task)table.GetType().GetMethod("ToListAsync").Invoke(table, new object[] { });
            await task.ConfigureAwait(false);
            var result = task.GetType().GetProperty("Result").GetValue(task);
            return result as IEnumerable;
        }

        public static async Task<bool> Vymazat(IData obj)
        {
            var vazby = VsechnyDbTridy.GroupBy(t => t).Select(g => new {
                Typ = g.Key,
                Vlastnosti = g.Key.GetProperties()
                    .Where(p => p.GetCustomAttribute<ReferenceAttribute>()?.Table == obj.GetType())
            }).Where(v => v.Vlastnosti.Count() > 0);

            foreach (var v in vazby)
            {
                string s = "";
                v.Vlastnosti.ForEach(p => s += (p.GetCustomAttribute<ColumnAttribute>()?.Name ?? p.Name) + $"={obj.Id} and ");
                s = s.Substring(0, s.Length - 4);
                int pocet = await DB.ExecuteScalarAsync<int>(String.Format(
                    "select count(*) from {0} where {1}", v.Typ.GetCustomAttribute<TableAttribute>()?.Name ?? v.Typ.Name, s));
                if (pocet > 0)
                    return false;
            }
            await DB.DeleteAsync(obj);
            return true;
        }
    }
}
