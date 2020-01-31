using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Acme.BookStore
{
    public class BookStoreTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IGuidGenerator _guidGenerator;

        public BookStoreTestDataSeedContributor(IRepository<Book, Guid> bookRepository, IGuidGenerator guidGenerator)
        {
            _bookRepository = bookRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            /* Seed additional test data... */
            var book = new Book
            {
                //Id = _guidGenerator.Create(),
                Name = "Foundation",
                Type = BookType.Fantastic,
                PublishDate = new DateTime(2015, 05, 24)
            };
            book.SetId(_guidGenerator.Create());
            await _bookRepository.InsertAsync(book);

            /*
            await _bookRepository.InsertAsync(new Book
            {
                Id = _guidGenerator.Create(),
                Name = "Test Book 1",
                Type = BookType.Fantastic,
                PublishDate = new DateTime(2015, 05, 24)
            });
            */

            book = new Book
            {
                //Id = _guidGenerator.Create(),
                Name = "Test Book 2",
                Type = BookType.Science,
                PublishDate = new DateTime(2014, 02, 11)
            };
            book.SetId(_guidGenerator.Create());
            await _bookRepository.InsertAsync(book);

            book = new Book
            {
                //Id = _guidGenerator.Create(),
                Name = "Test Book 3",
                Type = BookType.Poetry,
                PublishDate = new DateTime(2001, 02, 11)
            };
            book.SetId(_guidGenerator.Create());
            await _bookRepository.InsertAsync(book);

            //异步方法不需要 return Task.CompletedTask，否则，还会报错！！
            //return Task.CompletedTask;
        }
    }
}