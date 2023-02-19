using Domain.Common;

namespace Domain.Entities
{
    public class Header: Audit
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }        
        
        public ICollection<Detail>? Details { get; set; }

        private bool _status;

        public bool Status
        {
            get => _status;
            set
            {
               _status = value;
            }
        }
    }
}
