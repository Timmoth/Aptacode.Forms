﻿using Aptacode.Forms.Shared.Models;
using Aptacode.Forms.Shared.Models.Elements;
using Aptacode.Forms.Shared.Models.Elements.Fields;
using Aptacode.Forms.Shared.Models.Elements.Fields.ValidationRules;
using Aptacode.Forms.Shared.Models.Enums;
using Aptacode.Forms.Shared.Models.Layout;

namespace Aptacode.Forms.Wpf.FormDesigner.ViewModels
{
    public static class FormIO
    {
        public static FormModel ProgrammaticForm()
        {
            return new FormModel("form1", "Test Form",
                new[]
                {
                    new FormGroupModel("Test Form Group", new[]
                    {
                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel(1,
                                new HtmlElementModel("Paragraph",
                                    "<h1><em>Test HTML Content</em></h1>\r\n<p>Test</p>\r\n<p><strong><span style=\"background-color: #0000ff;\">Woop</span> woop</strong></p>\r\n<p><span style=\"text-decoration: underline; color: #003366;\">TEST od&nbsp;&nbsp; </span></p>",
                                    LabelPosition.AboveElement, "Sample HTML Content"))
                        }),

                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel(1,
                                new TextFieldModel("firstName", LabelPosition.AboveElement, "First Name",
                                    new[]
                                    {
                                        new TextFieldLengthValidationRule(EqualityOperator.GreaterThan, 2)
                                    })
                            ),
                            new FormColumnModel(1,
                                new TextFieldModel("lastName", LabelPosition.AboveElement, "Last Name",
                                    new[]
                                    {
                                        new TextFieldLengthValidationRule(
                                            EqualityOperator.LessThan | EqualityOperator.EqualTo, 10)
                                    })
                            )
                        }),

                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel(1,
                                new CheckBoxFieldModel("receiveEmail", LabelPosition.AboveElement,
                                    "Do you accept the terms and conditions",
                                    new[]
                                    {
                                        new CheckBoxCheckedValidationRule(true)
                                    }, "I Agree", false)
                            )
                        }),

                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel(1,
                                new ComboBoxFieldModel("yearsOfExperience", LabelPosition.AboveElement,
                                    "Years of Experience",
                                    new[]
                                    {
                                        new ComboBoxSelectionRequiredValidationRule()
                                    }, new[] {"0-1", "1-5", "5+"})
                            )
                        }),

                        new FormRowModel("Default", 1, new[]
                        {
                            new FormColumnModel(1,
                                new ButtonElementModel("SubmitButton",
                                    "Submit", LabelPosition.AboveElement, "")
                            )
                        })
                    })
                });
        }

        //public static void SaveForm(string filename, FormModel form)
        //{
        //   // File.WriteAllText(filename, form.ToJson());
        //}

        //public static FormModel LoadForm(string filename)
        //{
        //    var jsonString = File.ReadAllText(filename);
        //    return FormModel.FromJson(jsonString);
        //}
    }
}