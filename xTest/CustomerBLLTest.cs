using Autofac.Extras.Moq;
using CrBLL;
using Models;
using Moq;
using System.Collections.Generic;
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
                mock.Mock<CustomerBLL>()
                    .Setup(x => x.GetAll())
                    .Returns(getSamplePeople);

                var cls = mock.Create<CustomerBLL>();

                var expected = getSamplePeople();
                var actual = cls.GetAll() as List<ICustomer>;

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual?.Count);

                for (int i = 0; i < expected.Count && i < actual?.Count; i++)
                {
                    Assert.Equal(expected[i].CompanyName, actual[i].CompanyName);
                    Assert.Equal(expected[i].TradingName, actual[i].TradingName);
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

                mock.Mock<CustomerBLL>()
                    .Setup(x => x.Insert(customer));

                var cls = mock.Create<CustomerBLL>();
                cls.Insert(customer);

                mock.Mock<CustomerBLL>()
                    .Verify(x => x.Insert(customer), Times.Exactly(1));
            }
        }

        [Fact]
        public void Delete_Test()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customer = new Customer
                {
                    Id = "01",
                    CompanyName = "Acme LTDA",
                    TradingName = "Acme"
                };

                mock.Mock<CustomerBLL>()
                    .Setup(x => x.Insert(customer));

                var cls = mock.Create<CustomerBLL>();
                cls.Insert(customer);

                customer = new Customer
                {
                    Id = "10",
                    CompanyName = "Acme LTDA",
                    TradingName = "Acme"
                };

                cls.Insert(customer);

                cls.Delete("10");
                mock.Mock<CustomerBLL>()
                    .Verify(x => x.Delete("10"), Times.Exactly(1));
            }
        }

        private List<ICustomer> getSamplePeople()
        {
            var output = new List<ICustomer>
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
