﻿#if TEST


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingUtils;

namespace PurplePen.Tests
{
    [TestClass]
    public class CreateBitmapTests: TestFixtureBase
    {
        Controller controller;
        TestUI ui;

        [TestInitialize]
        public void Setup()
        {
            ui = TestUI.Create();
            controller = ui.controller;
        }


        // Create some courses, write them, and check against a dump.
        void CreateBitmapFiles(string file, BitmapCreationSettings settings, CourseAppearance appearance, 
                               string[] expectedBitmapNames, string[] expectedBitmapBaselines, 
                               string[] expectedTextNames = null, string[] expectedTextBaselines = null)
        {
            EventDB eventDB = controller.GetEventDB();

            for (int i = 0; i < expectedBitmapNames.Length; ++i) {
                File.Delete(expectedBitmapNames[i]);
            }

            if (expectedTextNames != null) {
                for (int i = 0; i < expectedTextNames.Length; ++i) {
                    File.Delete(expectedTextNames[i]);
                }
            }

            bool success = controller.LoadInitialFile(file, true);
            Assert.IsTrue(success);

            controller.SetCourseAppearance(appearance);

            for (int i = 0; i < expectedBitmapNames.Length; ++i) {
                File.Delete(expectedBitmapNames[i]);
            }

            if (expectedTextNames != null) {
                for (int i = 0; i < expectedTextNames.Length; ++i) {
                    File.Delete(expectedTextNames[i]);
                }
            }

            success = controller.CreateBitmapFiles(settings);
            Assert.IsTrue(success);

            for (int i = 0; i < expectedBitmapNames.Length; ++i) {
                TestUtil.CompareBitmapBaseline(expectedBitmapNames[i], expectedBitmapBaselines[i]);
            }

            if (expectedTextNames != null) {
                for (int i = 0; i < expectedTextNames.Length; ++i) {
                    TestUtil.CompareTextFileBaseline(expectedTextNames[i], expectedTextBaselines[i]);
                }
            }

            for (int i = 0; i < expectedBitmapNames.Length; ++i) {
                File.Delete(expectedBitmapNames[i]);
            }

            if (expectedTextNames != null) {
                for (int i = 0; i < expectedTextNames.Length; ++i) {
                    File.Delete(expectedTextNames[i]);
                }
            }
        }

        [TestMethod]
        public void BitmapCreation1()
        {
            BitmapCreationSettings settings = new BitmapCreationSettings();
            settings.mapDirectory = settings.fileDirectory = false;
            settings.outputDirectory = TestUtil.GetTestFile("bitmapcreate\\create1");
            settings.CourseIds = new Id<Course>[1] { CourseId(1) };
            settings.Dpi = 200;
            settings.ExportedBitmapKind = BitmapCreationSettings.BitmapKind.Jpeg;
 
            Directory.CreateDirectory(settings.outputDirectory);

            CreateBitmapFiles(TestUtil.GetTestFile("bitmapcreate\\GRC.ppen"), settings, new CourseAppearance(),
                new string[1] { TestUtil.GetTestFile("bitmapcreate\\create1\\Course 1.jpg") },
                new string[1] { TestUtil.GetTestFile("bitmapcreate\\create1\\Course 1_baseline.jpg") });
        }

        [TestMethod]
        public void BitmapCreation2()
        {
            BitmapCreationSettings settings = new BitmapCreationSettings();
            settings.mapDirectory = settings.fileDirectory = false;
            settings.outputDirectory = TestUtil.GetTestFile("bitmapcreate\\create2");
            settings.CourseIds = new Id<Course>[] { CourseId(0), CourseId(1), CourseId(2) };
            settings.Dpi = 200;
            settings.ExportedBitmapKind = BitmapCreationSettings.BitmapKind.Png;
            settings.ColorModel = ColorModel.RGB;
            settings.WorldFile = true;
            settings.filePrefix = "BM";

            Directory.CreateDirectory(settings.outputDirectory);

            CreateBitmapFiles(TestUtil.GetTestFile("bitmapcreate\\GRC.ppen"), settings, new CourseAppearance(),
                new string[3] { TestUtil.GetTestFile("bitmapcreate\\create2\\BM-All Controls.png"),
                                TestUtil.GetTestFile("bitmapcreate\\create2\\BM-Course 1.png"),
                                TestUtil.GetTestFile("bitmapcreate\\create2\\BM-Course 2.png")},
                new string[3] { TestUtil.GetTestFile("bitmapcreate\\create2\\BM_All Controls_baseline.png"),
                                TestUtil.GetTestFile("bitmapcreate\\create2\\BM_Course 1_baseline.png"),
                                TestUtil.GetTestFile("bitmapcreate\\create2\\BM_Course 2_baseline.png")},
                new string[] { TestUtil.GetTestFile("bitmapcreate\\create2\\BM-All Controls.pgw"),
                               TestUtil.GetTestFile("bitmapcreate\\create2\\BM-Course 1.pgw"),
                               TestUtil.GetTestFile("bitmapcreate\\create2\\BM-Course 2.pgw")},
                new string[] { TestUtil.GetTestFile("bitmapcreate\\create2\\BM-All Controls_baseline.pgw"),
                               TestUtil.GetTestFile("bitmapcreate\\create2\\BM-Course 1_baseline.pgw"),
                               TestUtil.GetTestFile("bitmapcreate\\create2\\BM-Course 2_baseline.pgw")}
                );
        }

        [TestMethod]
        public void BitmapCreation3()
        {
            BitmapCreationSettings settings = new BitmapCreationSettings();
            settings.mapDirectory = settings.fileDirectory = false;
            settings.outputDirectory = TestUtil.GetTestFile("bitmapcreate\\create3");
            settings.CourseIds = new Id<Course>[] { CourseId(3), CourseId(4) };
            settings.Dpi = 120;
            settings.ExportedBitmapKind = BitmapCreationSettings.BitmapKind.Gif;
            settings.ColorModel = ColorModel.CMYK;
            settings.filePrefix = "";

            Directory.CreateDirectory(settings.outputDirectory);

            CreateBitmapFiles(TestUtil.GetTestFile("bitmapcreate\\GRC.ppen"), settings, new CourseAppearance(),
                new string[] { TestUtil.GetTestFile("bitmapcreate\\create3\\Exchg-1.gif"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Exchg-2.gif"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Relay AC.gif"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Relay AD.gif"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Relay BC.gif"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Relay BD.gif"),
                },
                new string[] { TestUtil.GetTestFile("bitmapcreate\\create3\\Exchg-1_baseline.png"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Exchg-2_baseline.png"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Relay AC_baseline.png"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Relay AD_baseline.png"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Relay BC_baseline.png"),
                               TestUtil.GetTestFile("bitmapcreate\\create3\\Relay BD_baseline.png"),
                });
        }

        [TestMethod]
        public void BitmapCreation4()
        {
            BitmapCreationSettings settings = new BitmapCreationSettings();
            settings.mapDirectory = settings.fileDirectory = false;
            settings.outputDirectory = TestUtil.GetTestFile("bitmapcreate\\create4");
            settings.CourseIds = new Id<Course>[] { CourseId(1), CourseId(2) };
            settings.Dpi = 300;
            settings.ExportedBitmapKind = BitmapCreationSettings.BitmapKind.Jpeg;

            Directory.CreateDirectory(settings.outputDirectory);

            CreateBitmapFiles(TestUtil.GetTestFile("bitmapcreate\\StEd.ppen"), settings, new CourseAppearance(),
                new string[] { TestUtil.GetTestFile("bitmapcreate\\create4\\Course 1.jpg"),
                               TestUtil.GetTestFile("bitmapcreate\\create4\\Course 2.jpg")},
                new string[] { TestUtil.GetTestFile("bitmapcreate\\create4\\Course 1_baseline.png"),
                               TestUtil.GetTestFile("bitmapcreate\\create4\\Course 2_baseline.png")});
        }



    }
}

#endif