using Bonsai;
using Bonsai.Harp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Xml.Serialization;

namespace Harp.CameraControllerGen2
{
    /// <summary>
    /// Generates events and processes commands for the CameraControllerGen2 device connected
    /// at the specified serial port.
    /// </summary>
    [Combinator(MethodName = nameof(Generate))]
    [WorkflowElementCategory(ElementCategory.Source)]
    [Description("Generates events and processes commands for the CameraControllerGen2 device.")]
    public partial class Device : Bonsai.Harp.Device, INamedElement
    {
        /// <summary>
        /// Represents the unique identity class of the <see cref="CameraControllerGen2"/> device.
        /// This field is constant.
        /// </summary>
        public const int WhoAmI = 1170;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        public Device() : base(WhoAmI) { }

        string INamedElement.Name => nameof(CameraControllerGen2);

        /// <summary>
        /// Gets a read-only mapping from address to register type.
        /// </summary>
        public static new IReadOnlyDictionary<int, Type> RegisterMap { get; } = new Dictionary<int, Type>
            (Bonsai.Harp.Device.RegisterMap.ToDictionary(entry => entry.Key, entry => entry.Value))
        {
            { 32, typeof(Cam0Event) },
            { 33, typeof(Cam1Event) },
            { 34, typeof(ConfigureCam0Event) },
            { 35, typeof(ConfigureCam1Event) },
            { 36, typeof(StartAndStop) },
            { 37, typeof(StartAndStopTimestamped) },
            { 38, typeof(StartTimestamp) },
            { 39, typeof(StopTimestamp) },
            { 42, typeof(TriggerConfigCam0) },
            { 43, typeof(TriggerInvertedCam0) },
            { 44, typeof(StrobeSourceCam0) },
            { 45, typeof(TriggerFrequencyCam0) },
            { 46, typeof(TriggerDurationCam0) },
            { 49, typeof(TriggerConfigCam1) },
            { 50, typeof(TriggerInvertedCam1) },
            { 51, typeof(StrobeSourceCam1) },
            { 52, typeof(TriggerFrequencyCam1) },
            { 53, typeof(TriggerDurationCam1) },
            { 56, typeof(ConfigureOutput0) },
            { 57, typeof(ConfigureOutput1) },
            { 60, typeof(OutputSet) },
            { 61, typeof(OutputClear) },
            { 62, typeof(OutputToggle) },
            { 63, typeof(OutputState) },
            { 64, typeof(InputState) }
        };
    }

    /// <summary>
    /// Represents an operator that groups the sequence of <see cref="CameraControllerGen2"/>" messages by register type.
    /// </summary>
    [Description("Groups the sequence of CameraControllerGen2 messages by register type.")]
    public partial class GroupByRegister : Combinator<HarpMessage, IGroupedObservable<Type, HarpMessage>>
    {
        /// <summary>
        /// Groups an observable sequence of <see cref="CameraControllerGen2"/> messages
        /// by register type.
        /// </summary>
        /// <param name="source">The sequence of Harp device messages.</param>
        /// <returns>
        /// A sequence of observable groups, each of which corresponds to a unique
        /// <see cref="CameraControllerGen2"/> register.
        /// </returns>
        public override IObservable<IGroupedObservable<Type, HarpMessage>> Process(IObservable<HarpMessage> source)
        {
            return source.GroupBy(message => Device.RegisterMap[message.Address]);
        }
    }

    /// <summary>
    /// Represents an operator that filters register-specific messages
    /// reported by the <see cref="CameraControllerGen2"/> device.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    /// <seealso cref="Cam1Event"/>
    /// <seealso cref="ConfigureCam0Event"/>
    /// <seealso cref="ConfigureCam1Event"/>
    /// <seealso cref="StartAndStop"/>
    /// <seealso cref="StartAndStopTimestamped"/>
    /// <seealso cref="StartTimestamp"/>
    /// <seealso cref="StopTimestamp"/>
    /// <seealso cref="TriggerConfigCam0"/>
    /// <seealso cref="TriggerInvertedCam0"/>
    /// <seealso cref="StrobeSourceCam0"/>
    /// <seealso cref="TriggerFrequencyCam0"/>
    /// <seealso cref="TriggerDurationCam0"/>
    /// <seealso cref="TriggerConfigCam1"/>
    /// <seealso cref="TriggerInvertedCam1"/>
    /// <seealso cref="StrobeSourceCam1"/>
    /// <seealso cref="TriggerFrequencyCam1"/>
    /// <seealso cref="TriggerDurationCam1"/>
    /// <seealso cref="ConfigureOutput0"/>
    /// <seealso cref="ConfigureOutput1"/>
    /// <seealso cref="OutputSet"/>
    /// <seealso cref="OutputClear"/>
    /// <seealso cref="OutputToggle"/>
    /// <seealso cref="OutputState"/>
    /// <seealso cref="InputState"/>
    [XmlInclude(typeof(Cam0Event))]
    [XmlInclude(typeof(Cam1Event))]
    [XmlInclude(typeof(ConfigureCam0Event))]
    [XmlInclude(typeof(ConfigureCam1Event))]
    [XmlInclude(typeof(StartAndStop))]
    [XmlInclude(typeof(StartAndStopTimestamped))]
    [XmlInclude(typeof(StartTimestamp))]
    [XmlInclude(typeof(StopTimestamp))]
    [XmlInclude(typeof(TriggerConfigCam0))]
    [XmlInclude(typeof(TriggerInvertedCam0))]
    [XmlInclude(typeof(StrobeSourceCam0))]
    [XmlInclude(typeof(TriggerFrequencyCam0))]
    [XmlInclude(typeof(TriggerDurationCam0))]
    [XmlInclude(typeof(TriggerConfigCam1))]
    [XmlInclude(typeof(TriggerInvertedCam1))]
    [XmlInclude(typeof(StrobeSourceCam1))]
    [XmlInclude(typeof(TriggerFrequencyCam1))]
    [XmlInclude(typeof(TriggerDurationCam1))]
    [XmlInclude(typeof(ConfigureOutput0))]
    [XmlInclude(typeof(ConfigureOutput1))]
    [XmlInclude(typeof(OutputSet))]
    [XmlInclude(typeof(OutputClear))]
    [XmlInclude(typeof(OutputToggle))]
    [XmlInclude(typeof(OutputState))]
    [XmlInclude(typeof(InputState))]
    [Description("Filters register-specific messages reported by the CameraControllerGen2 device.")]
    public class FilterRegister : FilterRegisterBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterRegister"/> class.
        /// </summary>
        public FilterRegister()
        {
            Register = new Cam0Event();
        }

        string INamedElement.Name
        {
            get => $"{nameof(CameraControllerGen2)}.{GetElementDisplayName(Register)}";
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects specific messages
    /// reported by the CameraControllerGen2 device.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    /// <seealso cref="Cam1Event"/>
    /// <seealso cref="ConfigureCam0Event"/>
    /// <seealso cref="ConfigureCam1Event"/>
    /// <seealso cref="StartAndStop"/>
    /// <seealso cref="StartAndStopTimestamped"/>
    /// <seealso cref="StartTimestamp"/>
    /// <seealso cref="StopTimestamp"/>
    /// <seealso cref="TriggerConfigCam0"/>
    /// <seealso cref="TriggerInvertedCam0"/>
    /// <seealso cref="StrobeSourceCam0"/>
    /// <seealso cref="TriggerFrequencyCam0"/>
    /// <seealso cref="TriggerDurationCam0"/>
    /// <seealso cref="TriggerConfigCam1"/>
    /// <seealso cref="TriggerInvertedCam1"/>
    /// <seealso cref="StrobeSourceCam1"/>
    /// <seealso cref="TriggerFrequencyCam1"/>
    /// <seealso cref="TriggerDurationCam1"/>
    /// <seealso cref="ConfigureOutput0"/>
    /// <seealso cref="ConfigureOutput1"/>
    /// <seealso cref="OutputSet"/>
    /// <seealso cref="OutputClear"/>
    /// <seealso cref="OutputToggle"/>
    /// <seealso cref="OutputState"/>
    /// <seealso cref="InputState"/>
    [XmlInclude(typeof(Cam0Event))]
    [XmlInclude(typeof(Cam1Event))]
    [XmlInclude(typeof(ConfigureCam0Event))]
    [XmlInclude(typeof(ConfigureCam1Event))]
    [XmlInclude(typeof(StartAndStop))]
    [XmlInclude(typeof(StartAndStopTimestamped))]
    [XmlInclude(typeof(StartTimestamp))]
    [XmlInclude(typeof(StopTimestamp))]
    [XmlInclude(typeof(TriggerConfigCam0))]
    [XmlInclude(typeof(TriggerInvertedCam0))]
    [XmlInclude(typeof(StrobeSourceCam0))]
    [XmlInclude(typeof(TriggerFrequencyCam0))]
    [XmlInclude(typeof(TriggerDurationCam0))]
    [XmlInclude(typeof(TriggerConfigCam1))]
    [XmlInclude(typeof(TriggerInvertedCam1))]
    [XmlInclude(typeof(StrobeSourceCam1))]
    [XmlInclude(typeof(TriggerFrequencyCam1))]
    [XmlInclude(typeof(TriggerDurationCam1))]
    [XmlInclude(typeof(ConfigureOutput0))]
    [XmlInclude(typeof(ConfigureOutput1))]
    [XmlInclude(typeof(OutputSet))]
    [XmlInclude(typeof(OutputClear))]
    [XmlInclude(typeof(OutputToggle))]
    [XmlInclude(typeof(OutputState))]
    [XmlInclude(typeof(InputState))]
    [XmlInclude(typeof(TimestampedCam0Event))]
    [XmlInclude(typeof(TimestampedCam1Event))]
    [XmlInclude(typeof(TimestampedConfigureCam0Event))]
    [XmlInclude(typeof(TimestampedConfigureCam1Event))]
    [XmlInclude(typeof(TimestampedStartAndStop))]
    [XmlInclude(typeof(TimestampedStartAndStopTimestamped))]
    [XmlInclude(typeof(TimestampedStartTimestamp))]
    [XmlInclude(typeof(TimestampedStopTimestamp))]
    [XmlInclude(typeof(TimestampedTriggerConfigCam0))]
    [XmlInclude(typeof(TimestampedTriggerInvertedCam0))]
    [XmlInclude(typeof(TimestampedStrobeSourceCam0))]
    [XmlInclude(typeof(TimestampedTriggerFrequencyCam0))]
    [XmlInclude(typeof(TimestampedTriggerDurationCam0))]
    [XmlInclude(typeof(TimestampedTriggerConfigCam1))]
    [XmlInclude(typeof(TimestampedTriggerInvertedCam1))]
    [XmlInclude(typeof(TimestampedStrobeSourceCam1))]
    [XmlInclude(typeof(TimestampedTriggerFrequencyCam1))]
    [XmlInclude(typeof(TimestampedTriggerDurationCam1))]
    [XmlInclude(typeof(TimestampedConfigureOutput0))]
    [XmlInclude(typeof(TimestampedConfigureOutput1))]
    [XmlInclude(typeof(TimestampedOutputSet))]
    [XmlInclude(typeof(TimestampedOutputClear))]
    [XmlInclude(typeof(TimestampedOutputToggle))]
    [XmlInclude(typeof(TimestampedOutputState))]
    [XmlInclude(typeof(TimestampedInputState))]
    [Description("Filters and selects specific messages reported by the CameraControllerGen2 device.")]
    public partial class Parse : ParseBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parse"/> class.
        /// </summary>
        public Parse()
        {
            Register = new Cam0Event();
        }

        string INamedElement.Name => $"{nameof(CameraControllerGen2)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents an operator which formats a sequence of values as specific
    /// CameraControllerGen2 register messages.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    /// <seealso cref="Cam1Event"/>
    /// <seealso cref="ConfigureCam0Event"/>
    /// <seealso cref="ConfigureCam1Event"/>
    /// <seealso cref="StartAndStop"/>
    /// <seealso cref="StartAndStopTimestamped"/>
    /// <seealso cref="StartTimestamp"/>
    /// <seealso cref="StopTimestamp"/>
    /// <seealso cref="TriggerConfigCam0"/>
    /// <seealso cref="TriggerInvertedCam0"/>
    /// <seealso cref="StrobeSourceCam0"/>
    /// <seealso cref="TriggerFrequencyCam0"/>
    /// <seealso cref="TriggerDurationCam0"/>
    /// <seealso cref="TriggerConfigCam1"/>
    /// <seealso cref="TriggerInvertedCam1"/>
    /// <seealso cref="StrobeSourceCam1"/>
    /// <seealso cref="TriggerFrequencyCam1"/>
    /// <seealso cref="TriggerDurationCam1"/>
    /// <seealso cref="ConfigureOutput0"/>
    /// <seealso cref="ConfigureOutput1"/>
    /// <seealso cref="OutputSet"/>
    /// <seealso cref="OutputClear"/>
    /// <seealso cref="OutputToggle"/>
    /// <seealso cref="OutputState"/>
    /// <seealso cref="InputState"/>
    [XmlInclude(typeof(Cam0Event))]
    [XmlInclude(typeof(Cam1Event))]
    [XmlInclude(typeof(ConfigureCam0Event))]
    [XmlInclude(typeof(ConfigureCam1Event))]
    [XmlInclude(typeof(StartAndStop))]
    [XmlInclude(typeof(StartAndStopTimestamped))]
    [XmlInclude(typeof(StartTimestamp))]
    [XmlInclude(typeof(StopTimestamp))]
    [XmlInclude(typeof(TriggerConfigCam0))]
    [XmlInclude(typeof(TriggerInvertedCam0))]
    [XmlInclude(typeof(StrobeSourceCam0))]
    [XmlInclude(typeof(TriggerFrequencyCam0))]
    [XmlInclude(typeof(TriggerDurationCam0))]
    [XmlInclude(typeof(TriggerConfigCam1))]
    [XmlInclude(typeof(TriggerInvertedCam1))]
    [XmlInclude(typeof(StrobeSourceCam1))]
    [XmlInclude(typeof(TriggerFrequencyCam1))]
    [XmlInclude(typeof(TriggerDurationCam1))]
    [XmlInclude(typeof(ConfigureOutput0))]
    [XmlInclude(typeof(ConfigureOutput1))]
    [XmlInclude(typeof(OutputSet))]
    [XmlInclude(typeof(OutputClear))]
    [XmlInclude(typeof(OutputToggle))]
    [XmlInclude(typeof(OutputState))]
    [XmlInclude(typeof(InputState))]
    [Description("Formats a sequence of values as specific CameraControllerGen2 register messages.")]
    public partial class Format : FormatBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> class.
        /// </summary>
        public Format()
        {
            Register = new Cam0Event();
        }

        string INamedElement.Name => $"{nameof(CameraControllerGen2)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents a register that signals a frame was triggered on camera 0.
    /// </summary>
    [Description("Signals a frame was triggered on camera 0")]
    public partial class Cam0Event
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam0Event"/> register. This field is constant.
        /// </summary>
        public const int Address = 32;

        /// <summary>
        /// Represents the payload type of the <see cref="Cam0Event"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Cam0Event"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Cam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static CameraEvents GetPayload(HarpMessage message)
        {
            return (CameraEvents)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Cam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<CameraEvents> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((CameraEvents)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Cam0Event"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam0Event"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, CameraEvents value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Cam0Event"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam0Event"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, CameraEvents value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Cam0Event register.
    /// </summary>
    /// <seealso cref="Cam0Event"/>
    [Description("Filters and selects timestamped messages from the Cam0Event register.")]
    public partial class TimestampedCam0Event
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam0Event"/> register. This field is constant.
        /// </summary>
        public const int Address = Cam0Event.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Cam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<CameraEvents> GetPayload(HarpMessage message)
        {
            return Cam0Event.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that signals a frame was triggered on camera 1.
    /// </summary>
    [Description("Signals a frame was triggered on camera 1")]
    public partial class Cam1Event
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam1Event"/> register. This field is constant.
        /// </summary>
        public const int Address = 33;

        /// <summary>
        /// Represents the payload type of the <see cref="Cam1Event"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Cam1Event"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Cam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static CameraEvents GetPayload(HarpMessage message)
        {
            return (CameraEvents)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Cam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<CameraEvents> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((CameraEvents)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Cam1Event"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam1Event"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, CameraEvents value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Cam1Event"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Cam1Event"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, CameraEvents value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Cam1Event register.
    /// </summary>
    /// <seealso cref="Cam1Event"/>
    [Description("Filters and selects timestamped messages from the Cam1Event register.")]
    public partial class TimestampedCam1Event
    {
        /// <summary>
        /// Represents the address of the <see cref="Cam1Event"/> register. This field is constant.
        /// </summary>
        public const int Address = Cam1Event.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Cam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<CameraEvents> GetPayload(HarpMessage message)
        {
            return Cam1Event.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the event on camera 0.
    /// </summary>
    [Description("Configures the event on camera 0")]
    public partial class ConfigureCam0Event
    {
        /// <summary>
        /// Represents the address of the <see cref="ConfigureCam0Event"/> register. This field is constant.
        /// </summary>
        public const int Address = 34;

        /// <summary>
        /// Represents the payload type of the <see cref="ConfigureCam0Event"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="ConfigureCam0Event"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="ConfigureCam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static EventConfiguration GetPayload(HarpMessage message)
        {
            return (EventConfiguration)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="ConfigureCam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<EventConfiguration> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((EventConfiguration)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="ConfigureCam0Event"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ConfigureCam0Event"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, EventConfiguration value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="ConfigureCam0Event"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ConfigureCam0Event"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, EventConfiguration value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// ConfigureCam0Event register.
    /// </summary>
    /// <seealso cref="ConfigureCam0Event"/>
    [Description("Filters and selects timestamped messages from the ConfigureCam0Event register.")]
    public partial class TimestampedConfigureCam0Event
    {
        /// <summary>
        /// Represents the address of the <see cref="ConfigureCam0Event"/> register. This field is constant.
        /// </summary>
        public const int Address = ConfigureCam0Event.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="ConfigureCam0Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<EventConfiguration> GetPayload(HarpMessage message)
        {
            return ConfigureCam0Event.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the event on camera 0.
    /// </summary>
    [Description("Configures the event on camera 0")]
    public partial class ConfigureCam1Event
    {
        /// <summary>
        /// Represents the address of the <see cref="ConfigureCam1Event"/> register. This field is constant.
        /// </summary>
        public const int Address = 35;

        /// <summary>
        /// Represents the payload type of the <see cref="ConfigureCam1Event"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="ConfigureCam1Event"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="ConfigureCam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static EventConfiguration GetPayload(HarpMessage message)
        {
            return (EventConfiguration)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="ConfigureCam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<EventConfiguration> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((EventConfiguration)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="ConfigureCam1Event"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ConfigureCam1Event"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, EventConfiguration value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="ConfigureCam1Event"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ConfigureCam1Event"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, EventConfiguration value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// ConfigureCam1Event register.
    /// </summary>
    /// <seealso cref="ConfigureCam1Event"/>
    [Description("Filters and selects timestamped messages from the ConfigureCam1Event register.")]
    public partial class TimestampedConfigureCam1Event
    {
        /// <summary>
        /// Represents the address of the <see cref="ConfigureCam1Event"/> register. This field is constant.
        /// </summary>
        public const int Address = ConfigureCam1Event.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="ConfigureCam1Event"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<EventConfiguration> GetPayload(HarpMessage message)
        {
            return ConfigureCam1Event.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that starts and stops the cameras immediately.
    /// </summary>
    [Description("Starts and stops the cameras immediately")]
    public partial class StartAndStop
    {
        /// <summary>
        /// Represents the address of the <see cref="StartAndStop"/> register. This field is constant.
        /// </summary>
        public const int Address = 36;

        /// <summary>
        /// Represents the payload type of the <see cref="StartAndStop"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="StartAndStop"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StartAndStop"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static CameraFlags GetPayload(HarpMessage message)
        {
            return (CameraFlags)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StartAndStop"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<CameraFlags> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((CameraFlags)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StartAndStop"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartAndStop"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, CameraFlags value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StartAndStop"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartAndStop"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, CameraFlags value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StartAndStop register.
    /// </summary>
    /// <seealso cref="StartAndStop"/>
    [Description("Filters and selects timestamped messages from the StartAndStop register.")]
    public partial class TimestampedStartAndStop
    {
        /// <summary>
        /// Represents the address of the <see cref="StartAndStop"/> register. This field is constant.
        /// </summary>
        public const int Address = StartAndStop.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StartAndStop"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<CameraFlags> GetPayload(HarpMessage message)
        {
            return StartAndStop.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that starts and stops the cameras on a timestamp.
    /// </summary>
    [Description("Starts and stops the cameras on a timestamp")]
    public partial class StartAndStopTimestamped
    {
        /// <summary>
        /// Represents the address of the <see cref="StartAndStopTimestamped"/> register. This field is constant.
        /// </summary>
        public const int Address = 37;

        /// <summary>
        /// Represents the payload type of the <see cref="StartAndStopTimestamped"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="StartAndStopTimestamped"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StartAndStopTimestamped"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static CameraFlags GetPayload(HarpMessage message)
        {
            return (CameraFlags)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StartAndStopTimestamped"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<CameraFlags> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((CameraFlags)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StartAndStopTimestamped"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartAndStopTimestamped"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, CameraFlags value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StartAndStopTimestamped"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartAndStopTimestamped"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, CameraFlags value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StartAndStopTimestamped register.
    /// </summary>
    /// <seealso cref="StartAndStopTimestamped"/>
    [Description("Filters and selects timestamped messages from the StartAndStopTimestamped register.")]
    public partial class TimestampedStartAndStopTimestamped
    {
        /// <summary>
        /// Represents the address of the <see cref="StartAndStopTimestamped"/> register. This field is constant.
        /// </summary>
        public const int Address = StartAndStopTimestamped.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StartAndStopTimestamped"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<CameraFlags> GetPayload(HarpMessage message)
        {
            return StartAndStopTimestamped.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that specifies when the camera will start to acquire frames.
    /// </summary>
    [Description("Specifies when the camera will start to acquire frames")]
    public partial class StartTimestamp
    {
        /// <summary>
        /// Represents the address of the <see cref="StartTimestamp"/> register. This field is constant.
        /// </summary>
        public const int Address = 38;

        /// <summary>
        /// Represents the payload type of the <see cref="StartTimestamp"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U32;

        /// <summary>
        /// Represents the length of the <see cref="StartTimestamp"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StartTimestamp"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static uint GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StartTimestamp"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StartTimestamp"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartTimestamp"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StartTimestamp"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StartTimestamp"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StartTimestamp register.
    /// </summary>
    /// <seealso cref="StartTimestamp"/>
    [Description("Filters and selects timestamped messages from the StartTimestamp register.")]
    public partial class TimestampedStartTimestamp
    {
        /// <summary>
        /// Represents the address of the <see cref="StartTimestamp"/> register. This field is constant.
        /// </summary>
        public const int Address = StartTimestamp.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StartTimestamp"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetPayload(HarpMessage message)
        {
            return StartTimestamp.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that specifies when the camera will stop acquiring frames.
    /// </summary>
    [Description("Specifies when the camera will stop acquiring frames")]
    public partial class StopTimestamp
    {
        /// <summary>
        /// Represents the address of the <see cref="StopTimestamp"/> register. This field is constant.
        /// </summary>
        public const int Address = 39;

        /// <summary>
        /// Represents the payload type of the <see cref="StopTimestamp"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U32;

        /// <summary>
        /// Represents the length of the <see cref="StopTimestamp"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StopTimestamp"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static uint GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt32();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StopTimestamp"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt32();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StopTimestamp"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StopTimestamp"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StopTimestamp"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StopTimestamp"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, uint value)
        {
            return HarpMessage.FromUInt32(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StopTimestamp register.
    /// </summary>
    /// <seealso cref="StopTimestamp"/>
    [Description("Filters and selects timestamped messages from the StopTimestamp register.")]
    public partial class TimestampedStopTimestamp
    {
        /// <summary>
        /// Represents the address of the <see cref="StopTimestamp"/> register. This field is constant.
        /// </summary>
        public const int Address = StopTimestamp.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StopTimestamp"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<uint> GetPayload(HarpMessage message)
        {
            return StopTimestamp.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the trigger source for camera 0.
    /// </summary>
    [Description("Configures the trigger source for camera 0")]
    public partial class TriggerConfigCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerConfigCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = 42;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerConfigCam0"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="TriggerConfigCam0"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerConfigCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static TriggerSource GetPayload(HarpMessage message)
        {
            return (TriggerSource)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerConfigCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerSource> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((TriggerSource)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerConfigCam0"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerConfigCam0"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, TriggerSource value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerConfigCam0"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerConfigCam0"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, TriggerSource value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerConfigCam0 register.
    /// </summary>
    /// <seealso cref="TriggerConfigCam0"/>
    [Description("Filters and selects timestamped messages from the TriggerConfigCam0 register.")]
    public partial class TimestampedTriggerConfigCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerConfigCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerConfigCam0.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerConfigCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerSource> GetPayload(HarpMessage message)
        {
            return TriggerConfigCam0.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures whether trigger is inverted for camera 0.
    /// </summary>
    [Description("Configures whether trigger is inverted for camera 0")]
    public partial class TriggerInvertedCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerInvertedCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = 43;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerInvertedCam0"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="TriggerInvertedCam0"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerInvertedCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static TriggerInverted GetPayload(HarpMessage message)
        {
            return (TriggerInverted)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerInvertedCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInverted> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((TriggerInverted)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerInvertedCam0"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerInvertedCam0"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, TriggerInverted value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerInvertedCam0"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerInvertedCam0"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, TriggerInverted value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerInvertedCam0 register.
    /// </summary>
    /// <seealso cref="TriggerInvertedCam0"/>
    [Description("Filters and selects timestamped messages from the TriggerInvertedCam0 register.")]
    public partial class TimestampedTriggerInvertedCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerInvertedCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerInvertedCam0.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerInvertedCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInverted> GetPayload(HarpMessage message)
        {
            return TriggerInvertedCam0.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that select the strobe source line for camera 0. The direct line or with pull-up.
    /// </summary>
    [Description("Select the strobe source line for camera 0. The direct line or with pull-up.")]
    public partial class StrobeSourceCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="StrobeSourceCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = 44;

        /// <summary>
        /// Represents the payload type of the <see cref="StrobeSourceCam0"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="StrobeSourceCam0"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StrobeSourceCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static StrobeSource GetPayload(HarpMessage message)
        {
            return (StrobeSource)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StrobeSourceCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<StrobeSource> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((StrobeSource)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StrobeSourceCam0"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StrobeSourceCam0"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, StrobeSource value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StrobeSourceCam0"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StrobeSourceCam0"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, StrobeSource value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StrobeSourceCam0 register.
    /// </summary>
    /// <seealso cref="StrobeSourceCam0"/>
    [Description("Filters and selects timestamped messages from the StrobeSourceCam0 register.")]
    public partial class TimestampedStrobeSourceCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="StrobeSourceCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = StrobeSourceCam0.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StrobeSourceCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<StrobeSource> GetPayload(HarpMessage message)
        {
            return StrobeSourceCam0.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that specifies the trigger frequency for camera 0 between 1 and 1000.
    /// </summary>
    [Description("Specifies the trigger frequency for camera 0 between 1 and 1000")]
    public partial class TriggerFrequencyCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerFrequencyCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = 45;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerFrequencyCam0"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="TriggerFrequencyCam0"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerFrequencyCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerFrequencyCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerFrequencyCam0"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerFrequencyCam0"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerFrequencyCam0"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerFrequencyCam0"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerFrequencyCam0 register.
    /// </summary>
    /// <seealso cref="TriggerFrequencyCam0"/>
    [Description("Filters and selects timestamped messages from the TriggerFrequencyCam0 register.")]
    public partial class TimestampedTriggerFrequencyCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerFrequencyCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerFrequencyCam0.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerFrequencyCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return TriggerFrequencyCam0.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.
    /// </summary>
    [Description("Sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0")]
    public partial class TriggerDurationCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerDurationCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = 46;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerDurationCam0"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="TriggerDurationCam0"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerDurationCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerDurationCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerDurationCam0"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerDurationCam0"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerDurationCam0"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerDurationCam0"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerDurationCam0 register.
    /// </summary>
    /// <seealso cref="TriggerDurationCam0"/>
    [Description("Filters and selects timestamped messages from the TriggerDurationCam0 register.")]
    public partial class TimestampedTriggerDurationCam0
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerDurationCam0"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerDurationCam0.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerDurationCam0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return TriggerDurationCam0.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the trigger source for camera 1.
    /// </summary>
    [Description("Configures the trigger source for camera 1")]
    public partial class TriggerConfigCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerConfigCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = 49;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerConfigCam1"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="TriggerConfigCam1"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerConfigCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static TriggerSource GetPayload(HarpMessage message)
        {
            return (TriggerSource)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerConfigCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerSource> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((TriggerSource)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerConfigCam1"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerConfigCam1"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, TriggerSource value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerConfigCam1"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerConfigCam1"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, TriggerSource value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerConfigCam1 register.
    /// </summary>
    /// <seealso cref="TriggerConfigCam1"/>
    [Description("Filters and selects timestamped messages from the TriggerConfigCam1 register.")]
    public partial class TimestampedTriggerConfigCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerConfigCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerConfigCam1.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerConfigCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerSource> GetPayload(HarpMessage message)
        {
            return TriggerConfigCam1.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures whether trigger is inverted for camera 1.
    /// </summary>
    [Description("Configures whether trigger is inverted for camera 1")]
    public partial class TriggerInvertedCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerInvertedCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = 50;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerInvertedCam1"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="TriggerInvertedCam1"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerInvertedCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static TriggerInverted GetPayload(HarpMessage message)
        {
            return (TriggerInverted)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerInvertedCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInverted> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((TriggerInverted)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerInvertedCam1"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerInvertedCam1"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, TriggerInverted value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerInvertedCam1"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerInvertedCam1"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, TriggerInverted value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerInvertedCam1 register.
    /// </summary>
    /// <seealso cref="TriggerInvertedCam1"/>
    [Description("Filters and selects timestamped messages from the TriggerInvertedCam1 register.")]
    public partial class TimestampedTriggerInvertedCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerInvertedCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerInvertedCam1.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerInvertedCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<TriggerInverted> GetPayload(HarpMessage message)
        {
            return TriggerInvertedCam1.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that select the strobe source line for camera 1. The direct line or with pull-up.
    /// </summary>
    [Description("Select the strobe source line for camera 1. The direct line or with pull-up.")]
    public partial class StrobeSourceCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="StrobeSourceCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = 51;

        /// <summary>
        /// Represents the payload type of the <see cref="StrobeSourceCam1"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="StrobeSourceCam1"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="StrobeSourceCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static StrobeSource GetPayload(HarpMessage message)
        {
            return (StrobeSource)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="StrobeSourceCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<StrobeSource> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((StrobeSource)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="StrobeSourceCam1"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StrobeSourceCam1"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, StrobeSource value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="StrobeSourceCam1"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="StrobeSourceCam1"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, StrobeSource value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// StrobeSourceCam1 register.
    /// </summary>
    /// <seealso cref="StrobeSourceCam1"/>
    [Description("Filters and selects timestamped messages from the StrobeSourceCam1 register.")]
    public partial class TimestampedStrobeSourceCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="StrobeSourceCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = StrobeSourceCam1.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="StrobeSourceCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<StrobeSource> GetPayload(HarpMessage message)
        {
            return StrobeSourceCam1.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that specifies the trigger frequency for camera 1 between 1 and 1000.
    /// </summary>
    [Description("Specifies the trigger frequency for camera 1 between 1 and 1000")]
    public partial class TriggerFrequencyCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerFrequencyCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = 52;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerFrequencyCam1"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="TriggerFrequencyCam1"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerFrequencyCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerFrequencyCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerFrequencyCam1"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerFrequencyCam1"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerFrequencyCam1"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerFrequencyCam1"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerFrequencyCam1 register.
    /// </summary>
    /// <seealso cref="TriggerFrequencyCam1"/>
    [Description("Filters and selects timestamped messages from the TriggerFrequencyCam1 register.")]
    public partial class TimestampedTriggerFrequencyCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerFrequencyCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerFrequencyCam1.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerFrequencyCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return TriggerFrequencyCam1.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.
    /// </summary>
    [Description("Sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1")]
    public partial class TriggerDurationCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerDurationCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = 53;

        /// <summary>
        /// Represents the payload type of the <see cref="TriggerDurationCam1"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="TriggerDurationCam1"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="TriggerDurationCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="TriggerDurationCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="TriggerDurationCam1"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerDurationCam1"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="TriggerDurationCam1"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="TriggerDurationCam1"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// TriggerDurationCam1 register.
    /// </summary>
    /// <seealso cref="TriggerDurationCam1"/>
    [Description("Filters and selects timestamped messages from the TriggerDurationCam1 register.")]
    public partial class TimestampedTriggerDurationCam1
    {
        /// <summary>
        /// Represents the address of the <see cref="TriggerDurationCam1"/> register. This field is constant.
        /// </summary>
        public const int Address = TriggerDurationCam1.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="TriggerDurationCam1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return TriggerDurationCam1.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the digital Output 0.
    /// </summary>
    [Description("Configures the digital Output 0")]
    public partial class ConfigureOutput0
    {
        /// <summary>
        /// Represents the address of the <see cref="ConfigureOutput0"/> register. This field is constant.
        /// </summary>
        public const int Address = 56;

        /// <summary>
        /// Represents the payload type of the <see cref="ConfigureOutput0"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="ConfigureOutput0"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="ConfigureOutput0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static OutputConfiguration GetPayload(HarpMessage message)
        {
            return (OutputConfiguration)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="ConfigureOutput0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<OutputConfiguration> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((OutputConfiguration)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="ConfigureOutput0"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ConfigureOutput0"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, OutputConfiguration value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="ConfigureOutput0"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ConfigureOutput0"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, OutputConfiguration value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// ConfigureOutput0 register.
    /// </summary>
    /// <seealso cref="ConfigureOutput0"/>
    [Description("Filters and selects timestamped messages from the ConfigureOutput0 register.")]
    public partial class TimestampedConfigureOutput0
    {
        /// <summary>
        /// Represents the address of the <see cref="ConfigureOutput0"/> register. This field is constant.
        /// </summary>
        public const int Address = ConfigureOutput0.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="ConfigureOutput0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<OutputConfiguration> GetPayload(HarpMessage message)
        {
            return ConfigureOutput0.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configures the digital Output 1.
    /// </summary>
    [Description("Configures the digital Output 1")]
    public partial class ConfigureOutput1
    {
        /// <summary>
        /// Represents the address of the <see cref="ConfigureOutput1"/> register. This field is constant.
        /// </summary>
        public const int Address = 57;

        /// <summary>
        /// Represents the payload type of the <see cref="ConfigureOutput1"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="ConfigureOutput1"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="ConfigureOutput1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static OutputConfiguration GetPayload(HarpMessage message)
        {
            return (OutputConfiguration)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="ConfigureOutput1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<OutputConfiguration> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((OutputConfiguration)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="ConfigureOutput1"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ConfigureOutput1"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, OutputConfiguration value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="ConfigureOutput1"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="ConfigureOutput1"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, OutputConfiguration value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// ConfigureOutput1 register.
    /// </summary>
    /// <seealso cref="ConfigureOutput1"/>
    [Description("Filters and selects timestamped messages from the ConfigureOutput1 register.")]
    public partial class TimestampedConfigureOutput1
    {
        /// <summary>
        /// Represents the address of the <see cref="ConfigureOutput1"/> register. This field is constant.
        /// </summary>
        public const int Address = ConfigureOutput1.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="ConfigureOutput1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<OutputConfiguration> GetPayload(HarpMessage message)
        {
            return ConfigureOutput1.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that set the specified digital output lines.
    /// </summary>
    [Description("Set the specified digital output lines")]
    public partial class OutputSet
    {
        /// <summary>
        /// Represents the address of the <see cref="OutputSet"/> register. This field is constant.
        /// </summary>
        public const int Address = 60;

        /// <summary>
        /// Represents the payload type of the <see cref="OutputSet"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="OutputSet"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="OutputSet"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static DigitalOutputs GetPayload(HarpMessage message)
        {
            return (DigitalOutputs)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OutputSet"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalOutputs> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((DigitalOutputs)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OutputSet"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutputSet"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, DigitalOutputs value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OutputSet"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutputSet"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, DigitalOutputs value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OutputSet register.
    /// </summary>
    /// <seealso cref="OutputSet"/>
    [Description("Filters and selects timestamped messages from the OutputSet register.")]
    public partial class TimestampedOutputSet
    {
        /// <summary>
        /// Represents the address of the <see cref="OutputSet"/> register. This field is constant.
        /// </summary>
        public const int Address = OutputSet.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OutputSet"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalOutputs> GetPayload(HarpMessage message)
        {
            return OutputSet.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that clear the specified digital output lines.
    /// </summary>
    [Description("Clear the specified digital output lines")]
    public partial class OutputClear
    {
        /// <summary>
        /// Represents the address of the <see cref="OutputClear"/> register. This field is constant.
        /// </summary>
        public const int Address = 61;

        /// <summary>
        /// Represents the payload type of the <see cref="OutputClear"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="OutputClear"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="OutputClear"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static DigitalOutputs GetPayload(HarpMessage message)
        {
            return (DigitalOutputs)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OutputClear"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalOutputs> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((DigitalOutputs)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OutputClear"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutputClear"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, DigitalOutputs value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OutputClear"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutputClear"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, DigitalOutputs value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OutputClear register.
    /// </summary>
    /// <seealso cref="OutputClear"/>
    [Description("Filters and selects timestamped messages from the OutputClear register.")]
    public partial class TimestampedOutputClear
    {
        /// <summary>
        /// Represents the address of the <see cref="OutputClear"/> register. This field is constant.
        /// </summary>
        public const int Address = OutputClear.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OutputClear"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalOutputs> GetPayload(HarpMessage message)
        {
            return OutputClear.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that toggle the specified digital output lines.
    /// </summary>
    [Description("Toggle the specified digital output lines")]
    public partial class OutputToggle
    {
        /// <summary>
        /// Represents the address of the <see cref="OutputToggle"/> register. This field is constant.
        /// </summary>
        public const int Address = 62;

        /// <summary>
        /// Represents the payload type of the <see cref="OutputToggle"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="OutputToggle"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="OutputToggle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static DigitalOutputs GetPayload(HarpMessage message)
        {
            return (DigitalOutputs)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OutputToggle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalOutputs> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((DigitalOutputs)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OutputToggle"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutputToggle"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, DigitalOutputs value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OutputToggle"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutputToggle"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, DigitalOutputs value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OutputToggle register.
    /// </summary>
    /// <seealso cref="OutputToggle"/>
    [Description("Filters and selects timestamped messages from the OutputToggle register.")]
    public partial class TimestampedOutputToggle
    {
        /// <summary>
        /// Represents the address of the <see cref="OutputToggle"/> register. This field is constant.
        /// </summary>
        public const int Address = OutputToggle.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OutputToggle"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalOutputs> GetPayload(HarpMessage message)
        {
            return OutputToggle.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that write the state of all digital output lines.
    /// </summary>
    [Description("Write the state of all digital output lines")]
    public partial class OutputState
    {
        /// <summary>
        /// Represents the address of the <see cref="OutputState"/> register. This field is constant.
        /// </summary>
        public const int Address = 63;

        /// <summary>
        /// Represents the payload type of the <see cref="OutputState"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="OutputState"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="OutputState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static DigitalOutputs GetPayload(HarpMessage message)
        {
            return (DigitalOutputs)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="OutputState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalOutputs> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((DigitalOutputs)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="OutputState"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutputState"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, DigitalOutputs value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="OutputState"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="OutputState"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, DigitalOutputs value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// OutputState register.
    /// </summary>
    /// <seealso cref="OutputState"/>
    [Description("Filters and selects timestamped messages from the OutputState register.")]
    public partial class TimestampedOutputState
    {
        /// <summary>
        /// Represents the address of the <see cref="OutputState"/> register. This field is constant.
        /// </summary>
        public const int Address = OutputState.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="OutputState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalOutputs> GetPayload(HarpMessage message)
        {
            return OutputState.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that specifies the state of the digital Input 0.
    /// </summary>
    [Description("Specifies the state of the digital Input 0")]
    public partial class InputState
    {
        /// <summary>
        /// Represents the address of the <see cref="InputState"/> register. This field is constant.
        /// </summary>
        public const int Address = 64;

        /// <summary>
        /// Represents the payload type of the <see cref="InputState"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="InputState"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="InputState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static DigitalInputs GetPayload(HarpMessage message)
        {
            return (DigitalInputs)message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="InputState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalInputs> GetTimestampedPayload(HarpMessage message)
        {
            var payload = message.GetTimestampedPayloadByte();
            return Timestamped.Create((DigitalInputs)payload.Value, payload.Seconds);
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="InputState"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="InputState"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, DigitalInputs value)
        {
            return HarpMessage.FromByte(Address, messageType, (byte)value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="InputState"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="InputState"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, DigitalInputs value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, (byte)value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// InputState register.
    /// </summary>
    /// <seealso cref="InputState"/>
    [Description("Filters and selects timestamped messages from the InputState register.")]
    public partial class TimestampedInputState
    {
        /// <summary>
        /// Represents the address of the <see cref="InputState"/> register. This field is constant.
        /// </summary>
        public const int Address = InputState.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="InputState"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<DigitalInputs> GetPayload(HarpMessage message)
        {
            return InputState.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents an operator which creates standard message payloads for the
    /// CameraControllerGen2 device.
    /// </summary>
    /// <seealso cref="CreateCam0EventPayload"/>
    /// <seealso cref="CreateCam1EventPayload"/>
    /// <seealso cref="CreateConfigureCam0EventPayload"/>
    /// <seealso cref="CreateConfigureCam1EventPayload"/>
    /// <seealso cref="CreateStartAndStopPayload"/>
    /// <seealso cref="CreateStartAndStopTimestampedPayload"/>
    /// <seealso cref="CreateStartTimestampPayload"/>
    /// <seealso cref="CreateStopTimestampPayload"/>
    /// <seealso cref="CreateTriggerConfigCam0Payload"/>
    /// <seealso cref="CreateTriggerInvertedCam0Payload"/>
    /// <seealso cref="CreateStrobeSourceCam0Payload"/>
    /// <seealso cref="CreateTriggerFrequencyCam0Payload"/>
    /// <seealso cref="CreateTriggerDurationCam0Payload"/>
    /// <seealso cref="CreateTriggerConfigCam1Payload"/>
    /// <seealso cref="CreateTriggerInvertedCam1Payload"/>
    /// <seealso cref="CreateStrobeSourceCam1Payload"/>
    /// <seealso cref="CreateTriggerFrequencyCam1Payload"/>
    /// <seealso cref="CreateTriggerDurationCam1Payload"/>
    /// <seealso cref="CreateConfigureOutput0Payload"/>
    /// <seealso cref="CreateConfigureOutput1Payload"/>
    /// <seealso cref="CreateOutputSetPayload"/>
    /// <seealso cref="CreateOutputClearPayload"/>
    /// <seealso cref="CreateOutputTogglePayload"/>
    /// <seealso cref="CreateOutputStatePayload"/>
    /// <seealso cref="CreateInputStatePayload"/>
    [XmlInclude(typeof(CreateCam0EventPayload))]
    [XmlInclude(typeof(CreateCam1EventPayload))]
    [XmlInclude(typeof(CreateConfigureCam0EventPayload))]
    [XmlInclude(typeof(CreateConfigureCam1EventPayload))]
    [XmlInclude(typeof(CreateStartAndStopPayload))]
    [XmlInclude(typeof(CreateStartAndStopTimestampedPayload))]
    [XmlInclude(typeof(CreateStartTimestampPayload))]
    [XmlInclude(typeof(CreateStopTimestampPayload))]
    [XmlInclude(typeof(CreateTriggerConfigCam0Payload))]
    [XmlInclude(typeof(CreateTriggerInvertedCam0Payload))]
    [XmlInclude(typeof(CreateStrobeSourceCam0Payload))]
    [XmlInclude(typeof(CreateTriggerFrequencyCam0Payload))]
    [XmlInclude(typeof(CreateTriggerDurationCam0Payload))]
    [XmlInclude(typeof(CreateTriggerConfigCam1Payload))]
    [XmlInclude(typeof(CreateTriggerInvertedCam1Payload))]
    [XmlInclude(typeof(CreateStrobeSourceCam1Payload))]
    [XmlInclude(typeof(CreateTriggerFrequencyCam1Payload))]
    [XmlInclude(typeof(CreateTriggerDurationCam1Payload))]
    [XmlInclude(typeof(CreateConfigureOutput0Payload))]
    [XmlInclude(typeof(CreateConfigureOutput1Payload))]
    [XmlInclude(typeof(CreateOutputSetPayload))]
    [XmlInclude(typeof(CreateOutputClearPayload))]
    [XmlInclude(typeof(CreateOutputTogglePayload))]
    [XmlInclude(typeof(CreateOutputStatePayload))]
    [XmlInclude(typeof(CreateInputStatePayload))]
    [XmlInclude(typeof(CreateTimestampedCam0EventPayload))]
    [XmlInclude(typeof(CreateTimestampedCam1EventPayload))]
    [XmlInclude(typeof(CreateTimestampedConfigureCam0EventPayload))]
    [XmlInclude(typeof(CreateTimestampedConfigureCam1EventPayload))]
    [XmlInclude(typeof(CreateTimestampedStartAndStopPayload))]
    [XmlInclude(typeof(CreateTimestampedStartAndStopTimestampedPayload))]
    [XmlInclude(typeof(CreateTimestampedStartTimestampPayload))]
    [XmlInclude(typeof(CreateTimestampedStopTimestampPayload))]
    [XmlInclude(typeof(CreateTimestampedTriggerConfigCam0Payload))]
    [XmlInclude(typeof(CreateTimestampedTriggerInvertedCam0Payload))]
    [XmlInclude(typeof(CreateTimestampedStrobeSourceCam0Payload))]
    [XmlInclude(typeof(CreateTimestampedTriggerFrequencyCam0Payload))]
    [XmlInclude(typeof(CreateTimestampedTriggerDurationCam0Payload))]
    [XmlInclude(typeof(CreateTimestampedTriggerConfigCam1Payload))]
    [XmlInclude(typeof(CreateTimestampedTriggerInvertedCam1Payload))]
    [XmlInclude(typeof(CreateTimestampedStrobeSourceCam1Payload))]
    [XmlInclude(typeof(CreateTimestampedTriggerFrequencyCam1Payload))]
    [XmlInclude(typeof(CreateTimestampedTriggerDurationCam1Payload))]
    [XmlInclude(typeof(CreateTimestampedConfigureOutput0Payload))]
    [XmlInclude(typeof(CreateTimestampedConfigureOutput1Payload))]
    [XmlInclude(typeof(CreateTimestampedOutputSetPayload))]
    [XmlInclude(typeof(CreateTimestampedOutputClearPayload))]
    [XmlInclude(typeof(CreateTimestampedOutputTogglePayload))]
    [XmlInclude(typeof(CreateTimestampedOutputStatePayload))]
    [XmlInclude(typeof(CreateTimestampedInputStatePayload))]
    [Description("Creates standard message payloads for the CameraControllerGen2 device.")]
    public partial class CreateMessage : CreateMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMessage"/> class.
        /// </summary>
        public CreateMessage()
        {
            Payload = new CreateCam0EventPayload();
        }

        string INamedElement.Name => $"{nameof(CameraControllerGen2)}.{GetElementDisplayName(Payload)}";
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that signals a frame was triggered on camera 0.
    /// </summary>
    [DisplayName("Cam0EventPayload")]
    [Description("Creates a message payload that signals a frame was triggered on camera 0.")]
    public partial class CreateCam0EventPayload
    {
        /// <summary>
        /// Gets or sets the value that signals a frame was triggered on camera 0.
        /// </summary>
        [Description("The value that signals a frame was triggered on camera 0.")]
        public CameraEvents Cam0Event { get; set; }

        /// <summary>
        /// Creates a message payload for the Cam0Event register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public CameraEvents GetPayload()
        {
            return Cam0Event;
        }

        /// <summary>
        /// Creates a message that signals a frame was triggered on camera 0.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the Cam0Event register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.Cam0Event.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that signals a frame was triggered on camera 0.
    /// </summary>
    [DisplayName("TimestampedCam0EventPayload")]
    [Description("Creates a timestamped message payload that signals a frame was triggered on camera 0.")]
    public partial class CreateTimestampedCam0EventPayload : CreateCam0EventPayload
    {
        /// <summary>
        /// Creates a timestamped message that signals a frame was triggered on camera 0.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the Cam0Event register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.Cam0Event.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that signals a frame was triggered on camera 1.
    /// </summary>
    [DisplayName("Cam1EventPayload")]
    [Description("Creates a message payload that signals a frame was triggered on camera 1.")]
    public partial class CreateCam1EventPayload
    {
        /// <summary>
        /// Gets or sets the value that signals a frame was triggered on camera 1.
        /// </summary>
        [Description("The value that signals a frame was triggered on camera 1.")]
        public CameraEvents Cam1Event { get; set; }

        /// <summary>
        /// Creates a message payload for the Cam1Event register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public CameraEvents GetPayload()
        {
            return Cam1Event;
        }

        /// <summary>
        /// Creates a message that signals a frame was triggered on camera 1.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the Cam1Event register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.Cam1Event.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that signals a frame was triggered on camera 1.
    /// </summary>
    [DisplayName("TimestampedCam1EventPayload")]
    [Description("Creates a timestamped message payload that signals a frame was triggered on camera 1.")]
    public partial class CreateTimestampedCam1EventPayload : CreateCam1EventPayload
    {
        /// <summary>
        /// Creates a timestamped message that signals a frame was triggered on camera 1.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the Cam1Event register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.Cam1Event.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures the event on camera 0.
    /// </summary>
    [DisplayName("ConfigureCam0EventPayload")]
    [Description("Creates a message payload that configures the event on camera 0.")]
    public partial class CreateConfigureCam0EventPayload
    {
        /// <summary>
        /// Gets or sets the value that configures the event on camera 0.
        /// </summary>
        [Description("The value that configures the event on camera 0.")]
        public EventConfiguration ConfigureCam0Event { get; set; }

        /// <summary>
        /// Creates a message payload for the ConfigureCam0Event register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public EventConfiguration GetPayload()
        {
            return ConfigureCam0Event;
        }

        /// <summary>
        /// Creates a message that configures the event on camera 0.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the ConfigureCam0Event register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.ConfigureCam0Event.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures the event on camera 0.
    /// </summary>
    [DisplayName("TimestampedConfigureCam0EventPayload")]
    [Description("Creates a timestamped message payload that configures the event on camera 0.")]
    public partial class CreateTimestampedConfigureCam0EventPayload : CreateConfigureCam0EventPayload
    {
        /// <summary>
        /// Creates a timestamped message that configures the event on camera 0.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the ConfigureCam0Event register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.ConfigureCam0Event.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures the event on camera 0.
    /// </summary>
    [DisplayName("ConfigureCam1EventPayload")]
    [Description("Creates a message payload that configures the event on camera 0.")]
    public partial class CreateConfigureCam1EventPayload
    {
        /// <summary>
        /// Gets or sets the value that configures the event on camera 0.
        /// </summary>
        [Description("The value that configures the event on camera 0.")]
        public EventConfiguration ConfigureCam1Event { get; set; }

        /// <summary>
        /// Creates a message payload for the ConfigureCam1Event register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public EventConfiguration GetPayload()
        {
            return ConfigureCam1Event;
        }

        /// <summary>
        /// Creates a message that configures the event on camera 0.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the ConfigureCam1Event register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.ConfigureCam1Event.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures the event on camera 0.
    /// </summary>
    [DisplayName("TimestampedConfigureCam1EventPayload")]
    [Description("Creates a timestamped message payload that configures the event on camera 0.")]
    public partial class CreateTimestampedConfigureCam1EventPayload : CreateConfigureCam1EventPayload
    {
        /// <summary>
        /// Creates a timestamped message that configures the event on camera 0.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the ConfigureCam1Event register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.ConfigureCam1Event.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that starts and stops the cameras immediately.
    /// </summary>
    [DisplayName("StartAndStopPayload")]
    [Description("Creates a message payload that starts and stops the cameras immediately.")]
    public partial class CreateStartAndStopPayload
    {
        /// <summary>
        /// Gets or sets the value that starts and stops the cameras immediately.
        /// </summary>
        [Description("The value that starts and stops the cameras immediately.")]
        public CameraFlags StartAndStop { get; set; }

        /// <summary>
        /// Creates a message payload for the StartAndStop register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public CameraFlags GetPayload()
        {
            return StartAndStop;
        }

        /// <summary>
        /// Creates a message that starts and stops the cameras immediately.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the StartAndStop register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.StartAndStop.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that starts and stops the cameras immediately.
    /// </summary>
    [DisplayName("TimestampedStartAndStopPayload")]
    [Description("Creates a timestamped message payload that starts and stops the cameras immediately.")]
    public partial class CreateTimestampedStartAndStopPayload : CreateStartAndStopPayload
    {
        /// <summary>
        /// Creates a timestamped message that starts and stops the cameras immediately.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the StartAndStop register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.StartAndStop.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that starts and stops the cameras on a timestamp.
    /// </summary>
    [DisplayName("StartAndStopTimestampedPayload")]
    [Description("Creates a message payload that starts and stops the cameras on a timestamp.")]
    public partial class CreateStartAndStopTimestampedPayload
    {
        /// <summary>
        /// Gets or sets the value that starts and stops the cameras on a timestamp.
        /// </summary>
        [Description("The value that starts and stops the cameras on a timestamp.")]
        public CameraFlags StartAndStopTimestamped { get; set; }

        /// <summary>
        /// Creates a message payload for the StartAndStopTimestamped register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public CameraFlags GetPayload()
        {
            return StartAndStopTimestamped;
        }

        /// <summary>
        /// Creates a message that starts and stops the cameras on a timestamp.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the StartAndStopTimestamped register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.StartAndStopTimestamped.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that starts and stops the cameras on a timestamp.
    /// </summary>
    [DisplayName("TimestampedStartAndStopTimestampedPayload")]
    [Description("Creates a timestamped message payload that starts and stops the cameras on a timestamp.")]
    public partial class CreateTimestampedStartAndStopTimestampedPayload : CreateStartAndStopTimestampedPayload
    {
        /// <summary>
        /// Creates a timestamped message that starts and stops the cameras on a timestamp.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the StartAndStopTimestamped register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.StartAndStopTimestamped.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that specifies when the camera will start to acquire frames.
    /// </summary>
    [DisplayName("StartTimestampPayload")]
    [Description("Creates a message payload that specifies when the camera will start to acquire frames.")]
    public partial class CreateStartTimestampPayload
    {
        /// <summary>
        /// Gets or sets the value that specifies when the camera will start to acquire frames.
        /// </summary>
        [Description("The value that specifies when the camera will start to acquire frames.")]
        public uint StartTimestamp { get; set; }

        /// <summary>
        /// Creates a message payload for the StartTimestamp register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public uint GetPayload()
        {
            return StartTimestamp;
        }

        /// <summary>
        /// Creates a message that specifies when the camera will start to acquire frames.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the StartTimestamp register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.StartTimestamp.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that specifies when the camera will start to acquire frames.
    /// </summary>
    [DisplayName("TimestampedStartTimestampPayload")]
    [Description("Creates a timestamped message payload that specifies when the camera will start to acquire frames.")]
    public partial class CreateTimestampedStartTimestampPayload : CreateStartTimestampPayload
    {
        /// <summary>
        /// Creates a timestamped message that specifies when the camera will start to acquire frames.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the StartTimestamp register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.StartTimestamp.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that specifies when the camera will stop acquiring frames.
    /// </summary>
    [DisplayName("StopTimestampPayload")]
    [Description("Creates a message payload that specifies when the camera will stop acquiring frames.")]
    public partial class CreateStopTimestampPayload
    {
        /// <summary>
        /// Gets or sets the value that specifies when the camera will stop acquiring frames.
        /// </summary>
        [Description("The value that specifies when the camera will stop acquiring frames.")]
        public uint StopTimestamp { get; set; }

        /// <summary>
        /// Creates a message payload for the StopTimestamp register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public uint GetPayload()
        {
            return StopTimestamp;
        }

        /// <summary>
        /// Creates a message that specifies when the camera will stop acquiring frames.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the StopTimestamp register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.StopTimestamp.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that specifies when the camera will stop acquiring frames.
    /// </summary>
    [DisplayName("TimestampedStopTimestampPayload")]
    [Description("Creates a timestamped message payload that specifies when the camera will stop acquiring frames.")]
    public partial class CreateTimestampedStopTimestampPayload : CreateStopTimestampPayload
    {
        /// <summary>
        /// Creates a timestamped message that specifies when the camera will stop acquiring frames.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the StopTimestamp register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.StopTimestamp.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures the trigger source for camera 0.
    /// </summary>
    [DisplayName("TriggerConfigCam0Payload")]
    [Description("Creates a message payload that configures the trigger source for camera 0.")]
    public partial class CreateTriggerConfigCam0Payload
    {
        /// <summary>
        /// Gets or sets the value that configures the trigger source for camera 0.
        /// </summary>
        [Description("The value that configures the trigger source for camera 0.")]
        public TriggerSource TriggerConfigCam0 { get; set; }

        /// <summary>
        /// Creates a message payload for the TriggerConfigCam0 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public TriggerSource GetPayload()
        {
            return TriggerConfigCam0;
        }

        /// <summary>
        /// Creates a message that configures the trigger source for camera 0.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the TriggerConfigCam0 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerConfigCam0.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures the trigger source for camera 0.
    /// </summary>
    [DisplayName("TimestampedTriggerConfigCam0Payload")]
    [Description("Creates a timestamped message payload that configures the trigger source for camera 0.")]
    public partial class CreateTimestampedTriggerConfigCam0Payload : CreateTriggerConfigCam0Payload
    {
        /// <summary>
        /// Creates a timestamped message that configures the trigger source for camera 0.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the TriggerConfigCam0 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerConfigCam0.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures whether trigger is inverted for camera 0.
    /// </summary>
    [DisplayName("TriggerInvertedCam0Payload")]
    [Description("Creates a message payload that configures whether trigger is inverted for camera 0.")]
    public partial class CreateTriggerInvertedCam0Payload
    {
        /// <summary>
        /// Gets or sets the value that configures whether trigger is inverted for camera 0.
        /// </summary>
        [Description("The value that configures whether trigger is inverted for camera 0.")]
        public TriggerInverted TriggerInvertedCam0 { get; set; }

        /// <summary>
        /// Creates a message payload for the TriggerInvertedCam0 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public TriggerInverted GetPayload()
        {
            return TriggerInvertedCam0;
        }

        /// <summary>
        /// Creates a message that configures whether trigger is inverted for camera 0.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the TriggerInvertedCam0 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerInvertedCam0.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures whether trigger is inverted for camera 0.
    /// </summary>
    [DisplayName("TimestampedTriggerInvertedCam0Payload")]
    [Description("Creates a timestamped message payload that configures whether trigger is inverted for camera 0.")]
    public partial class CreateTimestampedTriggerInvertedCam0Payload : CreateTriggerInvertedCam0Payload
    {
        /// <summary>
        /// Creates a timestamped message that configures whether trigger is inverted for camera 0.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the TriggerInvertedCam0 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerInvertedCam0.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that select the strobe source line for camera 0. The direct line or with pull-up.
    /// </summary>
    [DisplayName("StrobeSourceCam0Payload")]
    [Description("Creates a message payload that select the strobe source line for camera 0. The direct line or with pull-up.")]
    public partial class CreateStrobeSourceCam0Payload
    {
        /// <summary>
        /// Gets or sets the value that select the strobe source line for camera 0. The direct line or with pull-up.
        /// </summary>
        [Description("The value that select the strobe source line for camera 0. The direct line or with pull-up.")]
        public StrobeSource StrobeSourceCam0 { get; set; }

        /// <summary>
        /// Creates a message payload for the StrobeSourceCam0 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public StrobeSource GetPayload()
        {
            return StrobeSourceCam0;
        }

        /// <summary>
        /// Creates a message that select the strobe source line for camera 0. The direct line or with pull-up.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the StrobeSourceCam0 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.StrobeSourceCam0.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that select the strobe source line for camera 0. The direct line or with pull-up.
    /// </summary>
    [DisplayName("TimestampedStrobeSourceCam0Payload")]
    [Description("Creates a timestamped message payload that select the strobe source line for camera 0. The direct line or with pull-up.")]
    public partial class CreateTimestampedStrobeSourceCam0Payload : CreateStrobeSourceCam0Payload
    {
        /// <summary>
        /// Creates a timestamped message that select the strobe source line for camera 0. The direct line or with pull-up.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the StrobeSourceCam0 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.StrobeSourceCam0.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that specifies the trigger frequency for camera 0 between 1 and 1000.
    /// </summary>
    [DisplayName("TriggerFrequencyCam0Payload")]
    [Description("Creates a message payload that specifies the trigger frequency for camera 0 between 1 and 1000.")]
    public partial class CreateTriggerFrequencyCam0Payload
    {
        /// <summary>
        /// Gets or sets the value that specifies the trigger frequency for camera 0 between 1 and 1000.
        /// </summary>
        [Description("The value that specifies the trigger frequency for camera 0 between 1 and 1000.")]
        public ushort TriggerFrequencyCam0 { get; set; }

        /// <summary>
        /// Creates a message payload for the TriggerFrequencyCam0 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public ushort GetPayload()
        {
            return TriggerFrequencyCam0;
        }

        /// <summary>
        /// Creates a message that specifies the trigger frequency for camera 0 between 1 and 1000.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the TriggerFrequencyCam0 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerFrequencyCam0.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that specifies the trigger frequency for camera 0 between 1 and 1000.
    /// </summary>
    [DisplayName("TimestampedTriggerFrequencyCam0Payload")]
    [Description("Creates a timestamped message payload that specifies the trigger frequency for camera 0 between 1 and 1000.")]
    public partial class CreateTimestampedTriggerFrequencyCam0Payload : CreateTriggerFrequencyCam0Payload
    {
        /// <summary>
        /// Creates a timestamped message that specifies the trigger frequency for camera 0 between 1 and 1000.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the TriggerFrequencyCam0 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerFrequencyCam0.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.
    /// </summary>
    [DisplayName("TriggerDurationCam0Payload")]
    [Description("Creates a message payload that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.")]
    public partial class CreateTriggerDurationCam0Payload
    {
        /// <summary>
        /// Gets or sets the value that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.
        /// </summary>
        [Description("The value that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.")]
        public ushort TriggerDurationCam0 { get; set; }

        /// <summary>
        /// Creates a message payload for the TriggerDurationCam0 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public ushort GetPayload()
        {
            return TriggerDurationCam0;
        }

        /// <summary>
        /// Creates a message that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the TriggerDurationCam0 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerDurationCam0.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.
    /// </summary>
    [DisplayName("TimestampedTriggerDurationCam0Payload")]
    [Description("Creates a timestamped message payload that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.")]
    public partial class CreateTimestampedTriggerDurationCam0Payload : CreateTriggerDurationCam0Payload
    {
        /// <summary>
        /// Creates a timestamped message that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 0.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the TriggerDurationCam0 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerDurationCam0.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures the trigger source for camera 1.
    /// </summary>
    [DisplayName("TriggerConfigCam1Payload")]
    [Description("Creates a message payload that configures the trigger source for camera 1.")]
    public partial class CreateTriggerConfigCam1Payload
    {
        /// <summary>
        /// Gets or sets the value that configures the trigger source for camera 1.
        /// </summary>
        [Description("The value that configures the trigger source for camera 1.")]
        public TriggerSource TriggerConfigCam1 { get; set; }

        /// <summary>
        /// Creates a message payload for the TriggerConfigCam1 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public TriggerSource GetPayload()
        {
            return TriggerConfigCam1;
        }

        /// <summary>
        /// Creates a message that configures the trigger source for camera 1.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the TriggerConfigCam1 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerConfigCam1.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures the trigger source for camera 1.
    /// </summary>
    [DisplayName("TimestampedTriggerConfigCam1Payload")]
    [Description("Creates a timestamped message payload that configures the trigger source for camera 1.")]
    public partial class CreateTimestampedTriggerConfigCam1Payload : CreateTriggerConfigCam1Payload
    {
        /// <summary>
        /// Creates a timestamped message that configures the trigger source for camera 1.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the TriggerConfigCam1 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerConfigCam1.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures whether trigger is inverted for camera 1.
    /// </summary>
    [DisplayName("TriggerInvertedCam1Payload")]
    [Description("Creates a message payload that configures whether trigger is inverted for camera 1.")]
    public partial class CreateTriggerInvertedCam1Payload
    {
        /// <summary>
        /// Gets or sets the value that configures whether trigger is inverted for camera 1.
        /// </summary>
        [Description("The value that configures whether trigger is inverted for camera 1.")]
        public TriggerInverted TriggerInvertedCam1 { get; set; }

        /// <summary>
        /// Creates a message payload for the TriggerInvertedCam1 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public TriggerInverted GetPayload()
        {
            return TriggerInvertedCam1;
        }

        /// <summary>
        /// Creates a message that configures whether trigger is inverted for camera 1.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the TriggerInvertedCam1 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerInvertedCam1.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures whether trigger is inverted for camera 1.
    /// </summary>
    [DisplayName("TimestampedTriggerInvertedCam1Payload")]
    [Description("Creates a timestamped message payload that configures whether trigger is inverted for camera 1.")]
    public partial class CreateTimestampedTriggerInvertedCam1Payload : CreateTriggerInvertedCam1Payload
    {
        /// <summary>
        /// Creates a timestamped message that configures whether trigger is inverted for camera 1.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the TriggerInvertedCam1 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerInvertedCam1.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that select the strobe source line for camera 1. The direct line or with pull-up.
    /// </summary>
    [DisplayName("StrobeSourceCam1Payload")]
    [Description("Creates a message payload that select the strobe source line for camera 1. The direct line or with pull-up.")]
    public partial class CreateStrobeSourceCam1Payload
    {
        /// <summary>
        /// Gets or sets the value that select the strobe source line for camera 1. The direct line or with pull-up.
        /// </summary>
        [Description("The value that select the strobe source line for camera 1. The direct line or with pull-up.")]
        public StrobeSource StrobeSourceCam1 { get; set; }

        /// <summary>
        /// Creates a message payload for the StrobeSourceCam1 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public StrobeSource GetPayload()
        {
            return StrobeSourceCam1;
        }

        /// <summary>
        /// Creates a message that select the strobe source line for camera 1. The direct line or with pull-up.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the StrobeSourceCam1 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.StrobeSourceCam1.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that select the strobe source line for camera 1. The direct line or with pull-up.
    /// </summary>
    [DisplayName("TimestampedStrobeSourceCam1Payload")]
    [Description("Creates a timestamped message payload that select the strobe source line for camera 1. The direct line or with pull-up.")]
    public partial class CreateTimestampedStrobeSourceCam1Payload : CreateStrobeSourceCam1Payload
    {
        /// <summary>
        /// Creates a timestamped message that select the strobe source line for camera 1. The direct line or with pull-up.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the StrobeSourceCam1 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.StrobeSourceCam1.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that specifies the trigger frequency for camera 1 between 1 and 1000.
    /// </summary>
    [DisplayName("TriggerFrequencyCam1Payload")]
    [Description("Creates a message payload that specifies the trigger frequency for camera 1 between 1 and 1000.")]
    public partial class CreateTriggerFrequencyCam1Payload
    {
        /// <summary>
        /// Gets or sets the value that specifies the trigger frequency for camera 1 between 1 and 1000.
        /// </summary>
        [Description("The value that specifies the trigger frequency for camera 1 between 1 and 1000.")]
        public ushort TriggerFrequencyCam1 { get; set; }

        /// <summary>
        /// Creates a message payload for the TriggerFrequencyCam1 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public ushort GetPayload()
        {
            return TriggerFrequencyCam1;
        }

        /// <summary>
        /// Creates a message that specifies the trigger frequency for camera 1 between 1 and 1000.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the TriggerFrequencyCam1 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerFrequencyCam1.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that specifies the trigger frequency for camera 1 between 1 and 1000.
    /// </summary>
    [DisplayName("TimestampedTriggerFrequencyCam1Payload")]
    [Description("Creates a timestamped message payload that specifies the trigger frequency for camera 1 between 1 and 1000.")]
    public partial class CreateTimestampedTriggerFrequencyCam1Payload : CreateTriggerFrequencyCam1Payload
    {
        /// <summary>
        /// Creates a timestamped message that specifies the trigger frequency for camera 1 between 1 and 1000.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the TriggerFrequencyCam1 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerFrequencyCam1.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.
    /// </summary>
    [DisplayName("TriggerDurationCam1Payload")]
    [Description("Creates a message payload that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.")]
    public partial class CreateTriggerDurationCam1Payload
    {
        /// <summary>
        /// Gets or sets the value that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.
        /// </summary>
        [Description("The value that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.")]
        public ushort TriggerDurationCam1 { get; set; }

        /// <summary>
        /// Creates a message payload for the TriggerDurationCam1 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public ushort GetPayload()
        {
            return TriggerDurationCam1;
        }

        /// <summary>
        /// Creates a message that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the TriggerDurationCam1 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerDurationCam1.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.
    /// </summary>
    [DisplayName("TimestampedTriggerDurationCam1Payload")]
    [Description("Creates a timestamped message payload that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.")]
    public partial class CreateTimestampedTriggerDurationCam1Payload : CreateTriggerDurationCam1Payload
    {
        /// <summary>
        /// Creates a timestamped message that sets the duration of the trigger pulse, in microseconds (minimum is 100), for camera 1.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the TriggerDurationCam1 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.TriggerDurationCam1.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures the digital Output 0.
    /// </summary>
    [DisplayName("ConfigureOutput0Payload")]
    [Description("Creates a message payload that configures the digital Output 0.")]
    public partial class CreateConfigureOutput0Payload
    {
        /// <summary>
        /// Gets or sets the value that configures the digital Output 0.
        /// </summary>
        [Description("The value that configures the digital Output 0.")]
        public OutputConfiguration ConfigureOutput0 { get; set; }

        /// <summary>
        /// Creates a message payload for the ConfigureOutput0 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public OutputConfiguration GetPayload()
        {
            return ConfigureOutput0;
        }

        /// <summary>
        /// Creates a message that configures the digital Output 0.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the ConfigureOutput0 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.ConfigureOutput0.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures the digital Output 0.
    /// </summary>
    [DisplayName("TimestampedConfigureOutput0Payload")]
    [Description("Creates a timestamped message payload that configures the digital Output 0.")]
    public partial class CreateTimestampedConfigureOutput0Payload : CreateConfigureOutput0Payload
    {
        /// <summary>
        /// Creates a timestamped message that configures the digital Output 0.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the ConfigureOutput0 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.ConfigureOutput0.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that configures the digital Output 1.
    /// </summary>
    [DisplayName("ConfigureOutput1Payload")]
    [Description("Creates a message payload that configures the digital Output 1.")]
    public partial class CreateConfigureOutput1Payload
    {
        /// <summary>
        /// Gets or sets the value that configures the digital Output 1.
        /// </summary>
        [Description("The value that configures the digital Output 1.")]
        public OutputConfiguration ConfigureOutput1 { get; set; }

        /// <summary>
        /// Creates a message payload for the ConfigureOutput1 register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public OutputConfiguration GetPayload()
        {
            return ConfigureOutput1;
        }

        /// <summary>
        /// Creates a message that configures the digital Output 1.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the ConfigureOutput1 register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.ConfigureOutput1.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that configures the digital Output 1.
    /// </summary>
    [DisplayName("TimestampedConfigureOutput1Payload")]
    [Description("Creates a timestamped message payload that configures the digital Output 1.")]
    public partial class CreateTimestampedConfigureOutput1Payload : CreateConfigureOutput1Payload
    {
        /// <summary>
        /// Creates a timestamped message that configures the digital Output 1.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the ConfigureOutput1 register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.ConfigureOutput1.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that set the specified digital output lines.
    /// </summary>
    [DisplayName("OutputSetPayload")]
    [Description("Creates a message payload that set the specified digital output lines.")]
    public partial class CreateOutputSetPayload
    {
        /// <summary>
        /// Gets or sets the value that set the specified digital output lines.
        /// </summary>
        [Description("The value that set the specified digital output lines.")]
        public DigitalOutputs OutputSet { get; set; }

        /// <summary>
        /// Creates a message payload for the OutputSet register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public DigitalOutputs GetPayload()
        {
            return OutputSet;
        }

        /// <summary>
        /// Creates a message that set the specified digital output lines.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the OutputSet register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.OutputSet.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that set the specified digital output lines.
    /// </summary>
    [DisplayName("TimestampedOutputSetPayload")]
    [Description("Creates a timestamped message payload that set the specified digital output lines.")]
    public partial class CreateTimestampedOutputSetPayload : CreateOutputSetPayload
    {
        /// <summary>
        /// Creates a timestamped message that set the specified digital output lines.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the OutputSet register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.OutputSet.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that clear the specified digital output lines.
    /// </summary>
    [DisplayName("OutputClearPayload")]
    [Description("Creates a message payload that clear the specified digital output lines.")]
    public partial class CreateOutputClearPayload
    {
        /// <summary>
        /// Gets or sets the value that clear the specified digital output lines.
        /// </summary>
        [Description("The value that clear the specified digital output lines.")]
        public DigitalOutputs OutputClear { get; set; }

        /// <summary>
        /// Creates a message payload for the OutputClear register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public DigitalOutputs GetPayload()
        {
            return OutputClear;
        }

        /// <summary>
        /// Creates a message that clear the specified digital output lines.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the OutputClear register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.OutputClear.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that clear the specified digital output lines.
    /// </summary>
    [DisplayName("TimestampedOutputClearPayload")]
    [Description("Creates a timestamped message payload that clear the specified digital output lines.")]
    public partial class CreateTimestampedOutputClearPayload : CreateOutputClearPayload
    {
        /// <summary>
        /// Creates a timestamped message that clear the specified digital output lines.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the OutputClear register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.OutputClear.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that toggle the specified digital output lines.
    /// </summary>
    [DisplayName("OutputTogglePayload")]
    [Description("Creates a message payload that toggle the specified digital output lines.")]
    public partial class CreateOutputTogglePayload
    {
        /// <summary>
        /// Gets or sets the value that toggle the specified digital output lines.
        /// </summary>
        [Description("The value that toggle the specified digital output lines.")]
        public DigitalOutputs OutputToggle { get; set; }

        /// <summary>
        /// Creates a message payload for the OutputToggle register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public DigitalOutputs GetPayload()
        {
            return OutputToggle;
        }

        /// <summary>
        /// Creates a message that toggle the specified digital output lines.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the OutputToggle register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.OutputToggle.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that toggle the specified digital output lines.
    /// </summary>
    [DisplayName("TimestampedOutputTogglePayload")]
    [Description("Creates a timestamped message payload that toggle the specified digital output lines.")]
    public partial class CreateTimestampedOutputTogglePayload : CreateOutputTogglePayload
    {
        /// <summary>
        /// Creates a timestamped message that toggle the specified digital output lines.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the OutputToggle register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.OutputToggle.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that write the state of all digital output lines.
    /// </summary>
    [DisplayName("OutputStatePayload")]
    [Description("Creates a message payload that write the state of all digital output lines.")]
    public partial class CreateOutputStatePayload
    {
        /// <summary>
        /// Gets or sets the value that write the state of all digital output lines.
        /// </summary>
        [Description("The value that write the state of all digital output lines.")]
        public DigitalOutputs OutputState { get; set; }

        /// <summary>
        /// Creates a message payload for the OutputState register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public DigitalOutputs GetPayload()
        {
            return OutputState;
        }

        /// <summary>
        /// Creates a message that write the state of all digital output lines.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the OutputState register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.OutputState.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that write the state of all digital output lines.
    /// </summary>
    [DisplayName("TimestampedOutputStatePayload")]
    [Description("Creates a timestamped message payload that write the state of all digital output lines.")]
    public partial class CreateTimestampedOutputStatePayload : CreateOutputStatePayload
    {
        /// <summary>
        /// Creates a timestamped message that write the state of all digital output lines.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the OutputState register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.OutputState.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a message payload
    /// that specifies the state of the digital Input 0.
    /// </summary>
    [DisplayName("InputStatePayload")]
    [Description("Creates a message payload that specifies the state of the digital Input 0.")]
    public partial class CreateInputStatePayload
    {
        /// <summary>
        /// Gets or sets the value that specifies the state of the digital Input 0.
        /// </summary>
        [Description("The value that specifies the state of the digital Input 0.")]
        public DigitalInputs InputState { get; set; }

        /// <summary>
        /// Creates a message payload for the InputState register.
        /// </summary>
        /// <returns>The created message payload value.</returns>
        public DigitalInputs GetPayload()
        {
            return InputState;
        }

        /// <summary>
        /// Creates a message that specifies the state of the digital Input 0.
        /// </summary>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new message for the InputState register.</returns>
        public HarpMessage GetMessage(MessageType messageType)
        {
            return Harp.CameraControllerGen2.InputState.FromPayload(messageType, GetPayload());
        }
    }

    /// <summary>
    /// Represents an operator that creates a timestamped message payload
    /// that specifies the state of the digital Input 0.
    /// </summary>
    [DisplayName("TimestampedInputStatePayload")]
    [Description("Creates a timestamped message payload that specifies the state of the digital Input 0.")]
    public partial class CreateTimestampedInputStatePayload : CreateInputStatePayload
    {
        /// <summary>
        /// Creates a timestamped message that specifies the state of the digital Input 0.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">Specifies the type of the created message.</param>
        /// <returns>A new timestamped message for the InputState register.</returns>
        public HarpMessage GetMessage(double timestamp, MessageType messageType)
        {
            return Harp.CameraControllerGen2.InputState.FromPayload(timestamp, messageType, GetPayload());
        }
    }

    /// <summary>
    /// Specifies active camera event flags.
    /// </summary>
    [Flags]
    public enum CameraEvents : byte
    {
        None = 0x0,
        Trigger = 0x1,
        Strobe = 0x2
    }

    /// <summary>
    /// Specifies operation flags for camera control.
    /// </summary>
    [Flags]
    public enum CameraFlags : byte
    {
        None = 0x0,
        StartCam0 = 0x1,
        StartCam1 = 0x2,
        StopCam0 = 0x4,
        StopCam1 = 0x8,
        SingleFrameCam0 = 0x10,
        SingleFrameCam1 = 0x20
    }

    /// <summary>
    /// Specifies the state of the digital input lines.
    /// </summary>
    [Flags]
    public enum DigitalInputs : byte
    {
        None = 0x0,
        DI0 = 0x1
    }

    /// <summary>
    /// Specifies the state of the digital output lines.
    /// </summary>
    [Flags]
    public enum DigitalOutputs : byte
    {
        None = 0x0,
        DO0 = 0x1,
        DO1 = 0x2
    }

    /// <summary>
    /// Specifies the operation of the camera events.
    /// </summary>
    public enum EventConfiguration : byte
    {
        /// <summary>
        /// Event is sent when the strobe goes from LOW to HIGH.
        /// </summary>
        EventOnStrobe = 0,

        /// <summary>
        /// Event is sent when the trigger goes from LOW to HIGH.
        /// </summary>
        EventOnTrigger = 1
    }

    /// <summary>
    /// Specifies the source for generating the trigger signal.
    /// </summary>
    public enum TriggerSource : byte
    {
        /// <summary>
        /// Trigger is controlled by the device TriggerXCamX registers.
        /// </summary>
        Internal = 0,

        /// <summary>
        /// Reserved, do not use.
        /// </summary>
        InternalReserved0 = 1,

        /// <summary>
        /// Trigger is synchronously generated at 1Hz.
        /// </summary>
        Internal1Hz = 2,

        /// <summary>
        /// Trigger is synchronously generated at 2Hz.
        /// </summary>
        Internal2Hz = 3,

        /// <summary>
        /// Trigger is synchronously generated at 5Hz.
        /// </summary>
        Internal5Hz = 4,

        /// <summary>
        /// Trigger is synchronously generated at 100Hz.
        /// </summary>
        Internal10Hz = 5,

        /// <summary>
        /// Reserved, do not use.
        /// </summary>
        InternalReserved1 = 6,

        /// <summary>
        /// Trigger is synchronously generated at 20Hz.
        /// </summary>
        Internal20Hz = 7,

        /// <summary>
        /// Reserved, do not use.
        /// </summary>
        InternalReserved2 = 8,

        /// <summary>
        /// Trigger is synchronously generated at 40Hz.
        /// </summary>
        Internal40Hz = 9,

        /// <summary>
        /// Trigger is synchronously generated at 50Hz.
        /// </summary>
        Internal50Hz = 10,

        /// <summary>
        /// Reserved, do not use.
        /// </summary>
        InternalReserved3 = 11,

        /// <summary>
        /// Reserved, do not use.
        /// </summary>
        InternalReserved4 = 12,

        /// <summary>
        /// Trigger is synchronously generated at 100Hz.
        /// </summary>
        Internal100Hz = 13,

        /// <summary>
        /// Trigger is synchronously generated at 125Hz.
        /// </summary>
        Internal125Hz = 14,

        /// <summary>
        /// Trigger is controlled by the external input 0.
        /// </summary>
        Input0 = 15
    }

    /// <summary>
    /// Specifies whether the camera trigger signal is inverted.
    /// </summary>
    public enum TriggerInverted : byte
    {
        /// <summary>
        /// Selects the direct line.
        /// </summary>
        No = 0,

        /// <summary>
        /// Selects the pull-up line.
        /// </summary>
        Yes = 1
    }

    /// <summary>
    /// Specifies the source for reading the strobe signal.
    /// </summary>
    public enum StrobeSource : byte
    {
        /// <summary>
        /// Selects the direct line.
        /// </summary>
        Direct = 0,

        /// <summary>
        /// Selects the pull-up line.
        /// </summary>
        PullUp = 1
    }

    /// <summary>
    /// Specifies the operation of the digital output line.
    /// </summary>
    public enum OutputConfiguration : byte
    {
        /// <summary>
        /// The digital output is controlled exclusively by software commands.
        /// </summary>
        Software = 0,

        /// <summary>
        /// The digital output follows the corresponding camera trigger (not inverted).
        /// </summary>
        TriggerCamera = 1,

        /// <summary>
        /// The digital output follows the corresponding camera strobe.
        /// </summary>
        StrobeCamera = 2
    }
}
