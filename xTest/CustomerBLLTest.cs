using Autofac.Extras.Moq;
using CrBLL;
using Models;
using MongoDbAccess;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UTest
{
    public class CustomerBllTest
    {
        [Fact]
        public void GetAll_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<MongoDbContext>()
                    .Setup(x => x.Customers)
                    .Returns(getSamplePeople);

                var cls = mock.Create<CustomerBLL>();

                var expected = getSamplePeople();
                var actual = cls.GetAll();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, (actual as List<Customer>).Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].CompanyName, (actual as List<Customer>)[i].CompanyName);
                    Assert.Equal(expected[i].TradingName, (actual as List<Customer>)[i].TradingName);
                }
            }
        }

        [Fact]
        public void Insert_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customer = new Customer
                {
                    CompanyName = "Acme LTDA",
                    TradingName = "Acme"
                };

                mock.Mock<MongoDbContext>()
                    .Setup(x => x.Insert(customer));

                var cls = mock.Create<CustomerBLL>();
                cls.Insert(customer);
                mock.Mock<MongoDbContext>()
                    .Verify(x => x.Insert(customer), Times.Exactly(1));
            }
        }

        private List<Customer> getSamplePeople()
        {
            var output = new List<Customer>
            {
                new Customer
                {
                    CompanyName = "Acme LTDA",
                    TradingName = "Acme"
                },
                new Customer
                {
                    CompanyName = "Gabriel Bauermann Co",
                    TradingName = "Gabriel",
                    CNPJ = "9908000/909-90"
                },
                new Customer
                {
                    CompanyName = "Companhia Brasileira de Software LTDA",
                    TradingName = "ComBraSoft",
                    Email = "contato@combrasoft.com"
                },
            };

            return output;
        }
    }
}
