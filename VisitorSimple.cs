using System;
using System.Collections.Generic;

namespace Patterns
{
    interface Visitor{
        public void Visit(Visitable visitable);
        public string process(List<Visitable> visitables);
    }
    
    interface Visitable{
        public void Accept(Visitor visitor);
        public string getRowValue();
        public string getJsonValue();
    }
    
    class ExportJson:Visitor{
        List<string> results = new List<string>();
        
        public string process(List<Visitable> visitables){
            string all = "";
            foreach(Visitable visitable in visitables){
                visitable.Accept(this);
            }
            
            foreach(string r in results){
                all+=r;
            }
            return all;
        }
        
        public void Visit(Visitable visitable){
            results.Add(visitable.getJsonValue());
        }
    }
    
    class ExportRaw:Visitor{
        List<string> results = new List<string>();
        
        public string process(List<Visitable> visitables){
            string all = "";
            foreach(Visitable visitable in visitables){
                visitable.Accept(this);
            }
            
            foreach(string r in results){
                all+=r;
            }
            return all;
        }
        
        public void Visit(Visitable visitable){
            results.Add(visitable.getRowValue());
        }
    }
    
    class ExcelFile:Visitable{
        public void Accept(Visitor visitor){
            visitor.Visit(this);   
        }
        
        public string getRowValue(){
            return "{..rowForExcel..}";
        }
        
        public string getJsonValue(){
            return "{..jsonForExcel..}";
        }
    }
    
    class ImageFile:Visitable{
        public void Accept(Visitor visitor){
            visitor.Visit(this);
        }
        
        public string getRowValue(){
            return "{..rowForImage..}";
        }
        
        public string getJsonValue(){
            return "{..jsonForImage..}";
        }
    }
    
    class TxtFile:Visitable{
        public void Accept(Visitor visitor){
            visitor.Visit(this);
        }
        
        public string getRowValue(){
            return "{..rowForTxt..}";
        }
        
        public string getJsonValue(){
            return "{..jsonForTxt..}";
        }
    }
    
    class CsvFile:Visitable{
        public void Accept(Visitor visitor){
            visitor.Visit(this);
        }
        
        public string getRowValue(){
            return "{..rowForCsv..}";
        }
        
        public string getJsonValue(){
            return "{..jsonForCsv..}";
        }
    }
    
    class VisitorSimple
    {
        public static void sample()
        {
            List<Visitable> visitables = new List<Visitable>();
            visitables.Add(new ExcelFile());
            visitables.Add(new ExcelFile());
            visitables.Add(new CsvFile());
            visitables.Add(new CsvFile());
            visitables.Add(new CsvFile());
            visitables.Add(new TxtFile());
            visitables.Add(new TxtFile());
            visitables.Add(new TxtFile());
            visitables.Add(new TxtFile());
            visitables.Add(new ImageFile());
            visitables.Add(new ImageFile());
            visitables.Add(new ImageFile());
            
            Visitor visitorRaw = new ExportRaw();
            Visitor visitorJson = new ExportJson();
            
            Console.WriteLine(visitorRaw.process(visitables));
            Console.WriteLine(visitorJson.process(visitables));
            
            
            Console.WriteLine("this is the sample for string");
        }
    }
}