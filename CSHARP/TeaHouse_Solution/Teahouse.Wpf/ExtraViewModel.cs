using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teahouse.Wpf
{
    class ExtraViewModel : ObservableObject
    {
        private int id;
        private string category;
        private string name;
        private int price;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }
        public string Category
        {
            get { return category; }
            set { Set(ref category, value); }
        }
        public string ExtraName
        {
            get { return name; }
            set { Set(ref name, value); }
        }
        public int Price
        {
            get { return price; }
            set { Set(ref price, value); }
        }

        public void CopyFrom(ExtraViewModel other)
        {
            if (other == null) return;
            this.Id = other.Id;
            this.Category = other.Category;
            this.ExtraName = other.ExtraName;
            this.Price = other.Price;
        }
    }
}
