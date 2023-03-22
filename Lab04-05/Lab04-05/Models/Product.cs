using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Lab04_05
{

    public partial class Product : INotifyPropertyChanged
    {
        private int _productCode;
        private string _pNameEn;
        private string _pNameRus;
        private decimal _price;
        private int _quantity;
        private string _pImage;
        private string _PDescriptionEn;
        private string _PDescriptionRus;
        private short _isActive;
        private int _productType;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
        }

        [Key]
        public int ProductCode 
        { 
            get
            {
                return _productCode;
            }
            set
            {
                _productCode = value;
                RaisePropertyChangedEvent("ProductCode");
            }
        }

        [Required(ErrorMessage = "WrongProductName")]
        [StringLength(45, ErrorMessage = "WrongProductName")]
        public string PNameEn 
        { 
            get
            {
                return _pNameEn;
            }
            set
            {
                _pNameEn = value;
                RaisePropertyChangedEvent("PNameEn");
            }
        }

        [Required(ErrorMessage = "WrongProductName")]
        [StringLength(45, ErrorMessage = "WrongProductName")]
        public string PNameRus
        {
            get
            {
                return _pNameRus;
            }
            set
            {
                _pNameRus = value;
                RaisePropertyChangedEvent("PNameRus");
            }
        }
        [Range(1, 10000, ErrorMessage = "WrongProductPrice")]
        public decimal Price 
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                RaisePropertyChangedEvent("Price");
            }
        }
        [Range(1, 100000, ErrorMessage = "WrongProductQuantity")]
        public int Quantity 
        { 
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                RaisePropertyChangedEvent("Quantity");
            }
        }

        [StringLength(150, ErrorMessage = "WrongImageSource")]
        public string PImage 
        { 
            get
            {
                return _pImage;
            }
            set
            {
                _pImage = value;
                RaisePropertyChangedEvent("PImage");
            }
        }

        [StringLength(500)]
        public string PDescriptionEn
        {
            get
            {
                return _PDescriptionEn;
            }
            set
            {
                _PDescriptionEn = value;
                RaisePropertyChangedEvent("PDescriptionEn");
            }
        }

        [StringLength(500)]
        public string PDescriptionRus
        {
            get
            {
                return _PDescriptionRus;
            }
            set
            {
                _PDescriptionRus = value;
                RaisePropertyChangedEvent("PDescriptionRus");
            }
        }

        public short isActive 
        { 
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                RaisePropertyChangedEvent("isActive");
            }
        }
        [Range(1, 4, ErrorMessage = "WrongProductType")]
        public int ProductType 
        { 
            get
            {
                return _productType;
            }
            set
            {
                _productType = value;
                RaisePropertyChangedEvent("ProductType");
            }
        }

        public virtual ProductType productType { get; set; }
    }
}
