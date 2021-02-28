using System.Collections;
using System.Collections.Generic;
using System;
using Arkham.Services;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    //[TestFixture]
    //public class ScreenResolutionAutoDetectTest
    //{
    //    [Test]
    //    public void SettingResolution_WhenCall_CheckScreenFullHDResolution()
    //    {
    //        //Arrange
    //        Resolution resolutionFullHDMock = new Resolution() { width = 1920, height = 1080 };
    //        Resolution resolutionHDMock = new Resolution() { width = 1280, height = 720 };
    //        IScreenResolutionAdapter screenResolutionAdapter = Substitute.For<IScreenResolutionAdapter>();
    //        screenResolutionAdapter.ResolutionsSupported.Returns(new Resolution[] { resolutionFullHDMock, resolutionHDMock });
    //        ScreenResolutionAutoDetect resolutionSetter = new ScreenResolutionAutoDetect(screenResolutionAdapter);

    //        //Act
    //        resolutionSetter.SettingResolution();

    //        //Assert
    //        screenResolutionAdapter.Received().SetResolution(1920, 1080, true, 60);
    //    }

    //    [Test]
    //    public void SettingResolution_WhenCall_CheckScreenHDResolution()
    //    {
    //        //Arrange
    //        Resolution resolutionHDMock = new Resolution() { width = 1280, height = 720 };
    //        IScreenResolutionAdapter screenResolutionAdapter = Substitute.For<IScreenResolutionAdapter>();
    //        screenResolutionAdapter.ResolutionsSupported.Returns(new Resolution[] { resolutionHDMock });
    //        ScreenResolutionAutoDetect resolutionSetter = new ScreenResolutionAutoDetect(screenResolutionAdapter);

    //        //Act
    //        resolutionSetter.SettingResolution();

    //        //Assert
    //        screenResolutionAdapter.Received().SetResolution(1280, 720, true, 60);
    //    }

    //    [TestCase(1920, 0)]
    //    [TestCase(1280, 0)]
    //    [TestCase(0, 1080)]
    //    [TestCase(0, 720)]
    //    [TestCase(0, 0)]
    //    public void SettingResolution_WhenCall_CheckResolutionNotSupported(int width, int height)
    //    {
    //        //Arrange
    //        IScreenResolutionAdapter screenResolutionAdapter = Substitute.For<IScreenResolutionAdapter>();
    //        Resolution resolutionMock = new Resolution() { width = width, height = height };
    //        screenResolutionAdapter.ResolutionsSupported.Returns(new Resolution[] { resolutionMock });
    //        ScreenResolutionAutoDetect resolutionSetter = new ScreenResolutionAutoDetect(screenResolutionAdapter);

    //        //Assert
    //        Assert.Throws<Exception>(() => resolutionSetter.SettingResolution());
    //    }
    //}
}
