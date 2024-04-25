namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;
    using Xunit;
    using Exercise002;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("12-2.1")]
        public void TestCorrectPrint()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.Main(null);
                Console.SetOut(stdout);

                Assert.Contains("This needs a using!", sw.ToString());
            }
        }
        [Fact]
        [Points("12-2.2")]
        public void TestIncorrectPrintNotFound()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.Main(null);
                Console.SetOut(stdout);

                Assert.DoesNotContain("This does not need using!", sw.ToString());
            }
        }

        [Fact]
        [Points("12-2.2")]
        public void CountSingleWriteLineInMain()
        {
            int counter = 0;
            AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(typeof(Program).Module.FullyQualifiedName);
            TypeDefinition type = assembly.MainModule.GetType(typeof(Program).FullName);
            MethodDefinition method = type.Methods.FirstOrDefault(m => m.Name == "Main");
            foreach (Instruction instruction in method.Body.Instructions)
            {
                if (instruction.OpCode != OpCodes.Call)
                {
                    continue;
                }

                if (instruction.Operand is not MethodReference methodReference)
                {
                    continue;
                }

                if (methodReference.FullName == "System.Void System.Console::WriteLine(System.String)")
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

        [Fact]
        [Points("12-2.1")]
        public void CountRegexInMain()
        {
            int counter = 0;
            AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(typeof(Program).Module.FullyQualifiedName);
            TypeDefinition type = assembly.MainModule.GetType(typeof(Program).FullName);
            MethodDefinition method = type.Methods.FirstOrDefault(m => m.Name == "Main");
            foreach (Instruction instruction in method.Body.Instructions)
            {
                if (instruction.OpCode != OpCodes.Newobj)
                {
                    continue;
                }

                if (instruction.Operand is not MethodReference methodReference)
                {
                    continue;
                }

                if (methodReference.FullName == "System.Void System.Text.RegularExpressions.Regex::.ctor(System.String)")
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

        [Fact]
        [Points("12-2.2")]
        public void CountLinq()
        {
            int counter = 0;
            AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(typeof(Program).Module.FullyQualifiedName);
            TypeDefinition type = assembly.MainModule.GetType(typeof(Program).FullName);
            MethodDefinition method = type.Methods.FirstOrDefault(m => m.Name == "Main");
            foreach (Instruction instruction in method.Body.Instructions)
            {
                if (instruction.OpCode != OpCodes.Call)
                {
                    continue;
                }

                if (instruction.Operand is not MethodReference methodReference)
                {
                    continue;
                }

                if (methodReference.FullName.Contains("System.Int32 System.Linq.Enumerable::Max") || methodReference.FullName.Contains("System.Int32 System.Linq.Enumerable::Min"))
                {
                    counter++;
                }
            }
            Assert.Equal(2, counter);
        }

        [Fact]
        [Points("12-2.2")]
        public void CountCollections()
        {
            int counter = 0;
            AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(typeof(Program).Module.FullyQualifiedName);
            TypeDefinition type = assembly.MainModule.GetType(typeof(Program).FullName);
            MethodDefinition method = type.Methods.FirstOrDefault(m => m.Name == "Main");
            foreach (Instruction instruction in method.Body.Instructions)
            {
                if (instruction.OpCode != OpCodes.Callvirt)
                {
                    continue;
                }

                if (instruction.Operand is not MethodReference methodReference)
                {
                    continue;
                }

                if (methodReference.FullName.Contains("System.Void System.Collections.Generic.List"))
                {
                    counter++;
                }
            }
            Assert.Equal(3, counter);
        }
    }
}
