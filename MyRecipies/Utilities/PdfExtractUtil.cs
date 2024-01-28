using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MyRecipies.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MyRecipies.Utilities
{
    internal static class PdfExtractUtil
    {
        private static RecipeReadOnlyDTO? _recipe;
        private static List<IngredientsRecReadOnlyDTO> _ingredients = new();
        internal static void CreateDocument(RecipeReadOnlyDTO recipe, List<IngredientsRecReadOnlyDTO> ingredients)
        {
            _recipe = recipe;
            _ingredients = ingredients;

            Document document = new();
            
            document.Info.Title = "Print recipe"; 
            DefineStyles(document);
            WriteText(document);

            PdfDocumentRenderer renderer = new PdfDocumentRenderer();
            renderer.Document = document;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(@"C:\Users\kolyv\Downloads\recipeprint.pdf");
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\kolyv\Downloads\recipeprint.pdf")
            {
                UseShellExecute = true
            };
            p.Start();

        }

        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Arial";
            style.Font.Size = 9;
            style.ParagraphFormat.SpaceAfter = 3;


            style = document.Styles.AddStyle("Title", "Normal");
            style.Font.Name = "Impact";
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.ParagraphFormat.SpaceAfter = 12;

            style = document.Styles["Heading1"];
            style.Font.Name = "Arial";
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Underline = Underline.Single;
            style.Font.Color = Colors.Blue;
            style.ParagraphFormat.SpaceAfter = 6;
            style.ParagraphFormat.SpaceAfter = 6;
        }

        private static void WriteText(Document document)
        {
            Section section = document.AddSection();

            if (_recipe is null) return;
            
            Paragraph paragraph = section.AddParagraph("", "Title");
            if (_recipe.RecipeName != null) paragraph.AddText(_recipe.RecipeName);


            if (_ingredients != null && _ingredients.Count > 0)
            {
                paragraph = section.AddParagraph("Συστατικά", "Heading");
                //paragraph = section.AddParagraph("", "Normal");
                foreach (var ingr in _ingredients)
                {
                    string text = "- ";
                    if (ingr.IngredientName != null) text += (ingr.IngredientName +" ");
                    if (ingr.Quantity != null) text += (ingr.Quantity + " ");
                    if (ingr.Comments != null) text += (ingr.Comments + " ");
                    paragraph = section.AddParagraph(text, "Normal");
                    paragraph.Format.LeftIndent = "1cm";
                }
                paragraph.AddLineBreak();
            }

            if(_recipe.Implementation != null)
            {
                paragraph = section.AddParagraph("Εκτέλεση", "Heading");
                paragraph = section.AddParagraph(_recipe.Implementation, "Normal");
            }



                
                    
        }

    }
}
