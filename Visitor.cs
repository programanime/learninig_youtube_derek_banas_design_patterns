using System;

namespace ConsoleApp1
{
    interface IVisitor{
        void Visit(Element element);
        void Visit(ElementL element);
    }
    
    interface IElement{
        void Accept(IVisitor visitor);
    }
    
    class Element:IElement{
        private double cost; 
        private string name; 
        public Element Next; 
        public Element Child; 
        
        public double Cost {
            get => cost; 
            set => cost = value;
        }
        
        public string Name {
            get => name; 
            set => name = value;
        }
        
        public virtual void Accept(IVisitor visitor){
            visitor.Visit(this);
        }
        
        public Element(){
            Console.ForegroundColor = ConsoleColor.Red; 
        }
        
        public Element(double cost, string name, Element next){
            Console.ForegroundColor = ConsoleColor.Green;
            this.cost = cost;
            this.name = name;
            this.Next = next;
            Console.WriteLine($"element {name}-> {cost}");
        }
        
        
    }
    
    class ElementL:Element{
        public ElementL(Element child, Element next){
            this.Next = next;
            this.Child = child;
        }
        
        public override void Accept(IVisitor visitor){
            visitor.Visit(this);
        }
    }
    
    class Visitor:IVisitor{
        private int count;
        private int classify;
        private double total;
        
        public int Count {
            get => count; 
            set => count = value;
        }
        
        public int Classify {
            get => classify; 
            set => classify = value;
        }
        
        public double Total {
            get => total; 
            set => total = value;
        }
        
        public void CountElements(Element element){
            element.Accept(this);
            if(element.Next != null){
                CountElements(element.Next);
            }
            
            if(element.Child != null){
                CountElements(element.Child);
            }
        }
        
        public void Visit(Element element){
            this.count++;
            this.total += element.Cost;
        }
        
        public void Visit(ElementL element){
            this.classify++;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("no count");
        }
    }
    
     
    class VisitorPattern
    {
        public static void run()
        {
            Console.WriteLine("visitor pattern");
            double totalCost  = 0d;
            int totalObjects = 0;
            int totalClassify = 0;
            Element structure = new Element(89.0, "Botiquin", 
                                new Element(25.0, "Termometro",
                                new ElementL(
                                    new Element(35.8, "Antibiotico",
                                    new Element(15.5, "Antiacido",
                                        new ElementL(
                                            new Element(12.8, "Aspirina",null),
                                            new Element(56.6, "Anti inflamatorio",
                                            null)))),
                                    new Element(12.8, "Gasa",
                                    new Element(23.5, "Cinta",
                                    new Element(112.5, "Tijeras",null))))));
                                    
            Visitor visitor = new Visitor();
            
            visitor.CountElements(structure);
            totalCost = visitor.Total;
            totalClassify = visitor.Classify;
            totalObjects = visitor.Count;
            
            Console.WriteLine($"we have {totalObjects} with {totalCost} for {totalClassify} classifications");
            
            Console.WriteLine("visitor pattern ends");
        }
    }
}