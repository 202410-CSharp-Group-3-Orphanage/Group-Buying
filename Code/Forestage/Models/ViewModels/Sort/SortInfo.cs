using System.Linq.Dynamic.Core;

namespace Forestage.Models.ViewModels.Sort
{
    public class SortInfo<T>
    {
        public IQueryable<T> ApplySort(IQueryable<T> data)
        {
            if (string.IsNullOrEmpty(this.ColumnName))
            {
                return data;
            }

            if (this.Direction == EnumDirection.Asc)
            {
                return data.OrderBy(this.ColumnName);
            }
            else
            {
                return data.OrderBy($"{this.ColumnName} descending");
            }
        }

        public SortInfo(string columnName, string direction)
        {
            this.ColumnName = columnName;
            this.Direction = Enum.TryParse(direction, out EnumDirection directionValue)
                ? directionValue
                : EnumDirection.Asc;
        }


        public string UrlTemplate { get; set; }

        public string GetQueryString()
        {
            string template = "ColumnName={0}&Direction={1}";
            return string.Format(template, this.ColumnName, this.Direction);
        }

        public string ColumnName { get; set; }
        public EnumDirection Direction { get; set; }

        public enum EnumDirection
        {
            Asc, Desc
        }
    }
}
