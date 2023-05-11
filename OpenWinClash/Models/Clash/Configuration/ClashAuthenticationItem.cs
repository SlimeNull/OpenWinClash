using System;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace OpenWinClash.Models.Clash.Configuration
{
    public record class ClashAuthenticationItem(string User, string Password);

    public class ClashAuthenticationItemConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type) => type == typeof(ClashAuthenticationItem);

        /// <summary>
        /// 读取一个 xxx:yyy 格式的字符串, 将 xxx 保存为类型的 User, yyy 保存为类型的 Password
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="YamlException"></exception>
        public object? ReadYaml(IParser parser, Type type)
        {
            if (!parser.Accept<Scalar>(out Scalar? scalar))
                throw new YamlException($"Cannot read yaml with type {type} from event {parser.Current}");
            parser.MoveNext();

            int colon = scalar.Value.IndexOf(':');
            if (colon < 1)
                throw new YamlException($"Cannot read yaml with type {type} from scalar {scalar.Value}");

            return new ClashAuthenticationItem(scalar.Value.Substring(0, colon), scalar.Value.Substring(colon + 1));
        }

        /// <summary>
        /// 写出一个字符串, $"{item.User}:{item.Password}"
        /// </summary>
        /// <param name="emitter"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <exception cref="YamlException"></exception>
        public void WriteYaml(IEmitter emitter, object? value, Type type)
        {
            if (value is not ClashAuthenticationItem clashAuthenticationItem)
                throw new YamlException($"Cannot write yaml with type {type}");

            emitter.Emit(new YamlDotNet.Core.Events.Scalar($"{clashAuthenticationItem.User}:{clashAuthenticationItem.Password}"));
        }
    }
}