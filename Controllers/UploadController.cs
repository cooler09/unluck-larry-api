using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using unlucky_larry.Models;

namespace unlucky_larry.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private QuestionContext _context;
        public UploadController(QuestionContext context)
        {
            _context = context;
        }
        [HttpPost,DisableRequestSizeLimit]
        public void UploadExcel()
        {
            try
            {
                var file = Request.Body;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    using (ExcelPackage package = new ExcelPackage(ms))
                    {
                        // add a new worksheet to the empty workbook
                        ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                        var start = worksheet.Dimension.Start;
                        var end = worksheet.Dimension.End;
                        for (int row = start.Row; row <= end.Row; row++)
                        { 
                            //skip headers
                            if(row ==1)
                                continue;
                            
                            var questionTitle = worksheet.Cells[row, 1].Value;
                            var a1 = worksheet.Cells[row, 2].Value;
                            var a2 = worksheet.Cells[row, 3].Value;
                            var a3 = worksheet.Cells[row, 4].Value;
                            var a4 = worksheet.Cells[row, 5].Value;
                            var correctIndex = worksheet.Cells[row, 6].Value;
                            var group = worksheet.Cells[row, 7].Value;
                            
                            if (questionTitle == null
                                || a1 == null
                                || a2 == null
                                || a3 == null
                                || a4 == null
                                || correctIndex == null
                                || group == null)
                            {
                                continue;

                            }
                            var question = new Question
                            {
                                GroupName = group.ToString(),
                                Title = questionTitle.ToString()
                            };

                            var answerOne = new Answer
                            {
                                Question = question,
                                Title = a1.ToString()
                            };
                            var answerTwo = new Answer
                            {
                                Question = question,
                                Title = a2.ToString()
                            };
                            var answerThree = new Answer
                            {
                                Question = question,
                                Title = a3.ToString()
                            };
                            var answerFour = new Answer
                            {
                                Question = question,
                                Title = a4.ToString()
                            };
                            _context.Questions.Add(question);
                            _context.Answers.Add(answerOne);
                            _context.Answers.Add(answerTwo);
                            _context.Answers.Add(answerThree);
                            _context.Answers.Add(answerFour);
                            _context.SaveChanges();
                            
                            
                            var q = _context.Questions.First(_ => _.Id == question.Id);
                            switch (correctIndex.ToString())
                            {
                                    case "1":
                                        q.CorrectAnswer = answerOne.Id;
                                        break;
                                    case "2" :
                                        q.CorrectAnswer = answerTwo.Id;
                                        break;
                                    case "3":
                                        q.CorrectAnswer = answerThree.Id;
                                        break;
                                    case "4":
                                        q.CorrectAnswer = answerFour.Id;
                                        break;
                            }
                            

                            _context.SaveChanges();
                        }
                    }
                }

//                string folderName = "Upload";
//                string webRootPath = _hostingEnvironment.WebRootPath;
//                string newPath = Path.Combine(webRootPath, folderName);
//                if (!Directory.Exists(newPath))
//                {
//                    Directory.CreateDirectory(newPath);
//                }
//                if (file.Length > 0)
//                {
//                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
//                    string fullPath = Path.Combine(newPath, fileName);
//                    using (var stream = new FileStream(fullPath, FileMode.Create))
//                    {
//                        file.CopyTo(stream);
//                    }
//                }
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}