using System;
using System.Diagnostics.CodeAnalysis;
using Escoteirando.Domain.ValueObjects;
using Xunit;

namespace Escoteirando.Domain.Tests
{
    [ExcludeFromCodeCoverage]
    public class CPFTests
    {
        [Theory]
        [InlineData("969.803.899-04")]
        [InlineData("93658877987")]
        public void TestValidCPFs(string cpf )
        {
            var c = new CPF(cpf);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("909090909")]
        [InlineData("12345678901")]
        public void TestInvalidCPFs(string cpf)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new CPF(cpf);
            });
        }
    }
}