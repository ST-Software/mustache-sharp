using System.Collections.Generic;
using System.IO;

namespace Mustache.Test
{
    public class TestInlineTag : InlineTagDefinition
    {
        public TestInlineTag() : base("testinlinetag")
        {
        }

        protected override bool GetHasContent()
        {
            return false;
        }

        public override void GetText(TextWriter writer, Dictionary<string, object> arguments, Scope context, Scope scope)
        {
            writer.Write(arguments["input"]);
        }

        protected override IEnumerable<TagParameter> GetParameters()
        {
            return new[] { new TagParameter("input"), };
        }

        public override bool IsInline
        {
            get { return true; }
        }
    }

    public class TestInlineTag2 : InlineTagDefinition
    {
        public TestInlineTag2()
            : base("translate")
        {
        }

        protected override bool GetHasContent()
        {
            return false;
        }

        public override void GetText(TextWriter writer, Dictionary<string, object> arguments, Scope context, Scope keyScope)
        {
//            var key = (string)arguments["key"];
//            var value = ((IDictionary<string, object>)arguments["data"])[key];
            object value;

            keyScope.TryFind((string)arguments["key"], out value);
            writer.Write(value);
        }

        public override IEnumerable<NestedContext> GetChildContext(TextWriter writer, Scope keyScope, Dictionary<string, object> arguments, Scope contextScope)
        {
            return base.GetChildContext(writer, keyScope, arguments, contextScope);
        }

        protected override IEnumerable<TagParameter> GetParameters()
        {
            return new[]
            {
                //new TagParameter("data"),
                new TagParameter("key"),
            };
        }

        public override bool IsInline
        {
            get { return true; }
        }
    }
}