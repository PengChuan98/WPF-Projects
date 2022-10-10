using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace QR.Test
{
    [TestClass]
    public class DialogServiceTests
    {
        [TestMethod]
        public void CanCallFilterBuilder()
        {
            // Arrange
            var suffix = "csv";

            // Act
            var result = DialogService.FilterBuilder(suffix, true);
            var resultWithoutAll = DialogService.FilterBuilder(suffix, false);

            Console.WriteLine(result);
            Console.WriteLine(resultWithoutAll);

            // List testing
            var suffixs = new List<string>() { "csv", "Word", "PDF" };

            result = DialogService.FilterBuilder(suffixs, true);
            resultWithoutAll = DialogService.FilterBuilder(suffixs, false);

            Console.WriteLine(result);
            Console.WriteLine(resultWithoutAll);
        }

        [TestMethod]
        public void CanCallOpenFileDlg()
        {
            // Arrange
            var filter = DialogService.FilterBuilder("csv",true);

            var suffixs = new List<string>() { "csv", "Word", "Pdf" };
            var filters = DialogService.FilterBuilder(suffixs, false);

            // Act
            DialogService.OpenFileDlg("所有文件(*.*)|*.*", out var path1);

            //Assert.IsTrue(DialogService.OpenFileDlg("图像文件(*.bmp, *.jpg)|*.bmp;*.jpg|所有文件(*.*)|*.*", out var path1));
            //Console.WriteLine(path1);

            //Assert.IsTrue(DialogService.OpenFileDlg(filters, out var path2));
            //Console.WriteLine(path2);
        }

    }
}