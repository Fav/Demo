using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectElu
{

   [Serializable]
    public class QueryCollection
    {
        private IList<string> orders = new List<string>();
        private int pageCount;
        private int pageIndex = 0;
        private PagerMode pagerMode = PagerMode.pmCustom;
        private int pageSize = 20;
        private IDictionary<string, object> queryParams = new Dictionary<string, object>();
        private int totalRecords = 0;
        private string sqlId = "";

        public void AddOrder(string propName, OrderStyle orderStyle)
        {
            if (orderStyle == OrderStyle.osUnknown)
            {
                Regex regex = new Regex("^ *" + propName + " *(desc)? *$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                
                for (int i = 0; i < this.orders.Count; i++)
                {
                    if (regex.IsMatch(this.orders[i]))
                    {
                        this.orders[i] = this.orders[i].Trim().EndsWith(" desc") ? propName : (propName + " desc");
                        return;
                    }
                }

                this.orders.Add(propName);
            }
            else
            {
                string str = (orderStyle == OrderStyle.osAsc) ? propName : (propName + " desc");

                if (this.orders.IndexOf(str) < 0)
                {
                    this.orders.Add(str);
                }
            }
        }

        public void AddQueryParam(string key, object val)
        {
            if ((val != null) && !string.IsNullOrEmpty(val.ToString()))
            {
                if (!this.ContainsQueryKey(key))
                {
                    this.queryParams.Add(key, val);
                }
                else
                {
                    this.queryParams[key] = val;
                }
            }
        }

        public void ClearOrders()
        {
            this.orders.Clear();
        }

        public void ClearOrders(string[] exceptPropNames)
        {
            for (int i = this.orders.Count - 1; i >= 0; i--)
            {
                bool flag = false;

                foreach (string str in exceptPropNames)
                {
                    Regex regex = new Regex("^ *" + str + " *$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    if (regex.IsMatch(this.orders[i]))
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    this.orders.RemoveAt(i);
                }
            }
        }

        public bool ContainsQueryKey(string key)
        {
            return this.queryParams.ContainsKey(key);
        }

        public object QueryValueByKey(string key)
        {
            if (this.ContainsQueryKey(key))
            {
                return this.queryParams[key];
            }

            return null;
        }

        public void RemoveQueryKey(string key)
        {
            if (this.ContainsQueryKey(key))
            {
                this.queryParams.Remove(key);
            }
        }

        public PagerMode CurrPagerMode
        {
            get
            {
                return this.pagerMode;
            }
            set
            {
                this.pagerMode = value;
            }
        }

        public IList<string> OrderExpressions
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
            }
        }

        public int PageCount
        {
            get
            {
                return this.pageCount;
            }
        }

        public int PageIndex
        {
            get
            {
                return this.pageIndex;
            }
            set
            {
                if (value >= 0)
                {
                    this.pageIndex = value;
                }
                else
                {
                    this.pageIndex = 0;
                }
            }
        }

        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                if (value > 0)
                {
                    this.pageSize = value;
                }
            }
        }

        public IEnumerator<string> QueryKeyEnumerator
        {
            get
            {
                return this.queryParams.Keys.GetEnumerator();
            }
        }

        public IDictionary<string, object> QueryParams
        {
            get
            {
                return this.queryParams;
            }
            set
            {
                if (value != null)
                {
                    this.queryParams = value;
                }
            }
        }

        public int QueryParamsCount
        {
            get
            {
                return this.queryParams.Count;
            }
        }

        public int TotalRecords
        {
            get
            {
                return this.totalRecords;
            }
            set
            {
                if (value >= 0)
                {
                    this.totalRecords = value;

                    if (this.pageSize > 0)
                    {
                        this.pageCount = this.totalRecords / this.pageSize;

                        if ((this.totalRecords % this.pageSize) > 0)
                        {
                            this.pageCount++;
                        }
                    }
                }

                if ((this.pageIndex >= this.pageCount) && (this.PageIndex > 0))
                {
                    this.pageIndex = this.pageCount - 1;
                }
            }
        }

        public int CurrentPage
        {
            get
            {
                return this.PageCount == 0 ? 0 : this.pageIndex + 1;
            }
        }

        public string SqlId
        {
            get
            {
                return sqlId;
            }
            set
            {
                sqlId = value;
            }
        }
    }

    public enum OrderStyle
    {
        osAsc,
        osDesc,
        osUnknown
    }

    public enum PagerMode
    {
        pmNone,
        pmCustom
    }
}