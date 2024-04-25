namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;
    using Xunit;
    using Exercise001;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("12-1.1")]
        public void TestMainIsUntouchedAndWorks()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.Main(null);

                Console.SetOut(stdout);
                string example = "ExampleMethod in NamespaceExample\nExampleMethod in InnerNamespaceExample\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("12-1.1")]
        public void CountNoWriteLinesInMain()
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
            Assert.Equal(0, counter);
        }

        [Fact]
        [Points("12-1.1")]
        public void CountNoWritesInMain()
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

                if (methodReference.FullName == "System.Void System.Console::Write(System.String)")
                {
                    counter++;
                }
            }
            Assert.Equal(0, counter);
        }

        [Fact]
        [Points("12-1.2")]
        public void CountNameSpaceExampleExampleCalls()
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

                if (methodReference.FullName == "System.Void NamespaceExample.Example::.ctor()")
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

        [Fact]
        [Points("12-1.2")]
        public void CountNameSpaceExampleMethodCalls()
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

                if (methodReference.FullName == "System.Void NamespaceExample.Example::ExampleMethod()")
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

        [Fact]
        [Points("12-1.2")]
        public void CountInnerNameSpaceExampleMethodCalls()
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

                if (methodReference.FullName == "System.Void NamespaceExample.InnerNamespaceExample.Example::ExampleMethod()")
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

        [Fact]
        [Points("12-1.2")]
        public void CountInnerNameSpaceExampleExampleCalls()
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

                if (methodReference.FullName == "System.Void NamespaceExample.InnerNamespaceExample.Example::.ctor()")
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }
    }
}
