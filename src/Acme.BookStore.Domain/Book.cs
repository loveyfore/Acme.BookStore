using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore
{
    public class Book : AuditedAggregateRoot<Guid>
    {

        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        //现在这个版本，Id的get是protected了，不允许在外面访问了！！反而不方便了！！
        public void SetId(Guid guid)
        {
            this.Id = guid;
        }
    }
}
