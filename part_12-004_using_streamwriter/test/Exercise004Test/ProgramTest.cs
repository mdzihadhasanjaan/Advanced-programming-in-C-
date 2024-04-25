namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;
    using Xunit;
    using Exercise004;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("12-4.1")]
        public void CountCreatingStreamWriters()
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

                if (methodReference.FullName.Contains("System.Void System.IO.StreamWriter::.ctor"))
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

        [Fact]
        [Points("12-4.1")]
        public void CountNoStringWritersAreUsed()
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

                if (methodReference.FullName.Contains("System.Void System.IO.StringWriter::.ctor"))
                {
                    counter++;
                }
            }
            Assert.Equal(0, counter);
        }

        [Fact]
        [Points("12-4.1")]
        public void CheckClosingIsRemoved()
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

                if (methodReference.FullName == ("System.Void System.IO.TextWriter::Close()"))
                {
                    counter++;
                }
            }
            Assert.Equal(0, counter);
        }

        [Fact]
        [Points("12-4.2")]
        public void CheckUsingIsUsed()
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

                if (methodReference.FullName == ("System.Void System.IDisposable::Dispose()"))
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

        [Fact]
        [Points("12-4.2")]
        public void WritesShouldRemainTheSame()
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

                if (methodReference.FullName == ("System.Void System.IO.TextWriter::WriteLine(System.String)") || methodReference.FullName == ("System.Void System.IO.TextWriter::Write(System.String)"))
                {
                    counter++;
                }
            }
            Assert.Equal(3, counter);
        }
    }
}
