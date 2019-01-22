using System;
using System.Collections.Generic;
using System.Text;
using Open.Aids;
using Open.Data.Rule;
namespace Open.Tests.Data.Rule
{
    public class VariableDataTests : ObjectTests<VariableData<string>>
    {
        private class testClass : VariableData<string> {
            protected override string toString(string value) {
                return value;
            }
            protected override string parseValue(string s) {
                return s;
            }
        }
        protected override VariableData<string> getRandomObject() {
            return GetRandom.Object<testClass>();
        }
    }
}
