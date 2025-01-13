using System.Linq.Dynamic.Core;

namespace Forestage.Models.Infra
{
    public class SortInfo<T>
    {
        public IQueryable<T> ApplySort(IQueryable<T> data)
        {
            if (string.IsNullOrEmpty(ColumnName))
            {
                return data;
            }

            if (Direction == EnumDirection.Asc)
            {
                return data.OrderBy(ColumnName);
            }
            else
            {
                return data.OrderBy($"{ColumnName} descending");
            }
        }

        public SortInfo(string columnName, string direction)
        {
            ColumnName = columnName;
            Direction = Enum.TryParse(direction, out EnumDirection directionValue)
                ? directionValue
                : EnumDirection.Asc;
        }


        public string UrlTemplate { get; set; }

        public string GetQueryString()
        {
            string template = "ColumnName={0}&Direction={1}";
            return string.Format(template, ColumnName, Direction);
        }

        public string ColumnName { get; set; }
        public EnumDirection Direction { get; set; }

        public enum EnumDirection
        {
            Asc, Desc
        }
    }
}
