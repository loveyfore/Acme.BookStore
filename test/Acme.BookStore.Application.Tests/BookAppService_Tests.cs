using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Volo.Abp.Application.Dtos;
using Shouldly;
using Volo.Abp.Validation;
using System.Linq;

namespace Acme.BookStore
{

    //1、首先修改为继承BookStoreApplicationTestBase
    //2、将类修改为public
    public class BookAppService_Tests : BookStoreApplicationTestBase
    {
        private readonly IBookAppService _bookAppService;

        public BookAppService_Tests()
        {
            _bookAppService = GetRequiredService<IBookAppService>();

        }

        [Fact]
        public async Task Should_Get_List_Of_Books()
        {
            //act
            var result = await _bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "Foundation");
        }
        [Fact]
        public async Task Should_Create_A_Valid_Book()
        {
            //Act
            var result = await _bookAppService.CreateAsync(
                new CreateUpdateBookDto
                {
                    Name = "New Test Book 42",
                    Price = 10,
                    PublishDate = DateTime.Now,
                    Type = BookType.ScienceFiction
                });

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New Test Book 42");
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            //Act
            var exception = await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _bookAppService.CreateAsync(
                        new CreateUpdateBookDto
                        {
                            Name = "",
                            Price = 10,
                            PublishDate = DateTime.Now,
                            Type = BookType.ScienceFiction
                        }) ;
                });

            //Assert
            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }

    }
}
