using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenWinClash.Models.Clash.Configuration;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace OpenWinClash.Utilities
{
    static class YamlUtils
    {
        private static readonly INamingConvention NamingConventionInstance =
            HyphenatedNamingConvention.Instance;

        private static readonly YamlEnumConverter YamlEnumConverterInstance =
            YamlEnumConverter.Create(NamingConventionInstance);

        private static readonly SerializerBuilder serializerBuilder = new SerializerBuilder()
            .WithNamingConvention(NamingConventionInstance)
            .WithTypeConverter(YamlEnumConverterInstance);

        private static readonly DeserializerBuilder deserializerBuilder = new DeserializerBuilder()
            .WithNamingConvention(NamingConventionInstance)
            .WithTypeConverter(YamlEnumConverterInstance)
            .WithTypeDiscriminatingNodeDeserializer(o =>
            {;
                // clash 代理类型映射
                o.AddKeyValueTypeDiscriminator<ClashProxy>(
                    NamingConventionInstance.Apply(nameof(ClashProxy.Type)), new Dictionary<string, Type>()
                    {
                        { YamlEnumConverterInstance.GetEnumString(ClashProxyType.Shadowsocks), typeof(ClashShadowsocksProxy) },
                        { YamlEnumConverterInstance.GetEnumString(ClashProxyType.VMess), typeof(ClashVMessProxy) },
                    });

                o.AddUniqueKeyTypeDiscriminator<ClashShadowsocksProxy>(
                    new Dictionary<string, Type>()
                    {
                        { NamingConventionInstance.Apply(nameof(ClashShadowsocksProxyWithPlugin.Plugin)), typeof(ClashShadowsocksProxyWithPlugin) }
                    });

                o.AddKeyValueTypeDiscriminator<ClashShadowsocksProxyWithPlugin>(
                    NamingConventionInstance.Apply(nameof(ClashShadowsocksProxyWithPlugin.Plugin)), new Dictionary<string, Type>()
                    {
                        {  NamingConventionInstance.Apply(nameof(ClashShadowsocksProxyPluginType.Obfs)), typeof(ClashShadowsocksProxyWithPlugin) }
                    });
            });


        private static readonly Lazy<ISerializer> laziedSerializer =
            new Lazy<ISerializer>(() => serializerBuilder.Build());

        private static readonly Lazy<IDeserializer> laziedDeserializer = 
            new Lazy<IDeserializer>(() => deserializerBuilder.Build());


        /// <summary>
        /// 全局静态 yaml 序列化器 (使用 - 连字符命名约定)
        /// </summary>
        public static ISerializer Serializer => laziedSerializer.Value;

        /// <summary>
        /// 全局静态 yaml 反序列化器 (从连字符转为大驼峰
        /// </summary>
        public static IDeserializer Deserializer => laziedDeserializer.Value;


        /// <summary>
        /// 用于 YAML 的枚举转换器
        /// </summary>
        private class YamlEnumConverter : IYamlTypeConverter
        {
            private YamlEnumConverter(INamingConvention? namingConvention)
            {
                NamingConvention = namingConvention;
            }

            public INamingConvention? NamingConvention { get; }

            public static YamlEnumConverter Create(INamingConvention? namingConvention) =>
                new YamlEnumConverter(namingConvention);

            public bool Accepts(Type type) => type.IsEnum;

            public string GetEnumString(object? enumValue, Type type)
            {
                return 
                    type.GetCustomAttribute<EnumMemberAttribute>()?.Value ??
                    NamingConvention?.Apply($"{enumValue}") ?? $"{enumValue}";
            }

            public string GetEnumString<TEnum>(TEnum enumValue)
            {
                return GetEnumString(enumValue, typeof(TEnum));
            }

            public object? ReadYaml(IParser parser, Type type)
            {
                var scalar =
                    parser.Consume<Scalar>();

                var enumValues =
                    Enum.GetValues(type);

                foreach (var enumValue in enumValues)
                {
                    var enumValueStr =
                        enumValue.ToString()!;

                    if (enumValueStr == scalar.Value ||
                        NamingConvention?.Apply(enumValueStr) == scalar.Value ||
                        enumValue.GetType().GetCustomAttribute<EnumMemberAttribute>()?.Value == scalar.Value)
                        return enumValue;
                }

                throw new YamlException(scalar.Start, scalar.End, $"Value '{scalar.Value}' not found in Enum {type}");
            }

            public void WriteYaml(IEmitter emitter, object? value, Type type)
            {
                if (value == null)
                {
                    emitter.Emit(new Scalar("null"));
                    return;
                }

                string write =
                    GetEnumString(value, type);

                if (string.IsNullOrWhiteSpace(write))
                    throw new YamlException($"Cannot write {value} to yaml");

                emitter.Emit(new Scalar(write));
            }
        }
    }
}
