using NUnit.Framework;
using System;
using TestCSharp.Question1;

namespace UnitTests
{
    class UnitTestsQuestion1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetNumberOfMovies_FromMock_Pass()
        {
            int total = MovieService.getNumberOfMovies("maze");
            Assert.AreEqual(3, total);
            Assert.Pass();
        }

        [Test]
        public void InvalidArgument_TitleNull_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => MovieService.getNumberOfMovies(null));
        }

        [Test]
        public void InvalidArgument_TitleInvalidLength_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => MovieService.getNumberOfMovies(""));
            Assert.Throws<ArgumentException>(() => MovieService.getNumberOfMovies("abcdefghijklmnopqrstu"));
        }

        [Test]
        public void InvalidArgument_TitleValidBorderLength_Pass()
        {
            MovieService.getNumberOfMovies("abcdefghijklmnopqrst");
            Assert.Pass();
        }

    }
}

