﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using P3Net.Kraken.Data.Common;
using P3Net.Kraken.UnitTesting;

namespace Tests.P3Net.Kraken.Data.Common
{
    [TestClass]
    public class OutputParameterTTests : UnitTest
    {
        #region Ctor
        
        [TestMethod]
        public void Ctor_WithName ()
        {
            var target = new OutputParameter<int>("@p1");

            //Assert
            target.Name.Should().Be("@p1");
            target.DbType.Should().Be(DbType.Int32);
        }

        [TestMethod]
        public void Ctor_NameIsEmpty ()
        {
            Action action = () => new OutputParameter<int>("");

            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void Ctor_NameIsNull ()
        {
            Action action = () => new OutputParameter<int>(null);

            action.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void Ctor_WithUnknownType ()
        {
            var target = new OutputParameter<Tuple<string>>("@p1");

            //Assert
            target.DbType.Should().Be(DbType.Object);
        }
        #endregion
    }
}
