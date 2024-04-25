namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Linq;
    using Mono.Cecil;
    using Mono.Cecil.Cil;
    using Xunit;
    using Exercise003;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("12-3.1")]
        public void TestSystemUsing()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.Main(null);

                Console.SetOut(stdout);
                string example = "Can we fix it? Yes we can!\n";
                Assert.Contains(example, sw.ToString());
            }
        }

        [Fact]
        [Points("12-3.1")]
        public void CountCreatingMasters()
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

                if (methodReference.FullName == ("System.Void MasterProject.MasterClass::.ctor()"))
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

        [Fact]
        [Points("12-3.2")]
        public void CountMasterUses()
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
                if (methodReference.FullName == ("System.Void MasterProject.MasterClass::Master()"))
                {
                    counter++;
                }
            }
            Assert.Equal(1, counter);
        }

    }
}
