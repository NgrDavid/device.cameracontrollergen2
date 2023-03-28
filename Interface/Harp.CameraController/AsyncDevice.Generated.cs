using Bonsai.Harp;
using System.Threading.Tasks;

namespace Harp.CameraController
{
    /// <inheritdoc/>
    public partial class Device
    {
        /// <summary>
        /// Initializes a new instance of the asynchronous API to configure and interface
        /// with CameraController devices on the specified serial port.
        /// </summary>
        /// <param name="portName">
        /// The name of the serial port used to communicate with the Harp device.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous initialization operation. The value of
        /// the <see cref="Task{TResult}.Result"/> parameter contains a new instance of
        /// the <see cref="AsyncDevice"/> class.
        /// </returns>
        public static async Task<AsyncDevice> CreateAsync(string portName)
        {
            var device = new AsyncDevice(portName);
            var whoAmI = await device.ReadWhoAmIAsync();
            if (whoAmI != Device.WhoAmI)
            {
                var errorMessage = string.Format(
                    "The device ID {1} on {0} was unexpected. Check whether a CameraController device is connected to the specified serial port.",
                    portName, whoAmI);
                throw new HarpException(errorMessage);
            }

            return device;
        }
    }

    /// <summary>
    /// Represents an asynchronous API to configure and interface with CameraController devices.
    /// </summary>
    public partial class AsyncDevice : Bonsai.Harp.AsyncDevice
    {
        internal AsyncDevice(string portName)
            : base(portName)
        {
        }

        /// <summary>
        /// Asynchronously reads the contents of the Cam0Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadCam0EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Cam0Event.Address));
            return Cam0Event.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Cam0Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedCam0EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Cam0Event.Address));
            return Cam0Event.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Cam1Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadCam1EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Cam1Event.Address));
            return Cam1Event.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Cam1Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedCam1EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Cam1Event.Address));
            return Cam1Event.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the ConfigureCam0Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadConfigureCam0EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ConfigureCam0Event.Address));
            return ConfigureCam0Event.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the ConfigureCam0Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedConfigureCam0EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ConfigureCam0Event.Address));
            return ConfigureCam0Event.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the ConfigureCam0Event register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteConfigureCam0EventAsync(byte value)
        {
            var request = ConfigureCam0Event.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the ConfigureCam1Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadConfigureCam1EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ConfigureCam1Event.Address));
            return ConfigureCam1Event.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the ConfigureCam1Event register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedConfigureCam1EventAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ConfigureCam1Event.Address));
            return ConfigureCam1Event.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the ConfigureCam1Event register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteConfigureCam1EventAsync(byte value)
        {
            var request = ConfigureCam1Event.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StartAndStop register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadStartAndStopAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StartAndStop.Address));
            return StartAndStop.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StartAndStop register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedStartAndStopAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StartAndStop.Address));
            return StartAndStop.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StartAndStop register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStartAndStopAsync(byte value)
        {
            var request = StartAndStop.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StartAndStopTimestamped register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadStartAndStopTimestampedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StartAndStopTimestamped.Address));
            return StartAndStopTimestamped.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StartAndStopTimestamped register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedStartAndStopTimestampedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StartAndStopTimestamped.Address));
            return StartAndStopTimestamped.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StartAndStopTimestamped register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStartAndStopTimestampedAsync(byte value)
        {
            var request = StartAndStopTimestamped.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StartTimestamp register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<uint> ReadStartTimestampAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(StartTimestamp.Address));
            return StartTimestamp.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StartTimestamp register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<uint>> ReadTimestampedStartTimestampAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(StartTimestamp.Address));
            return StartTimestamp.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StartTimestamp register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStartTimestampAsync(uint value)
        {
            var request = StartTimestamp.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StopTimestamp register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<uint> ReadStopTimestampAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(StopTimestamp.Address));
            return StopTimestamp.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StopTimestamp register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<uint>> ReadTimestampedStopTimestampAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt32(StopTimestamp.Address));
            return StopTimestamp.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StopTimestamp register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStopTimestampAsync(uint value)
        {
            var request = StopTimestamp.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerConfigCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadTriggerConfigCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerConfigCam0.Address));
            return TriggerConfigCam0.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerConfigCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedTriggerConfigCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerConfigCam0.Address));
            return TriggerConfigCam0.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerConfigCam0 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerConfigCam0Async(byte value)
        {
            var request = TriggerConfigCam0.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerInvertedCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadTriggerInvertedCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerInvertedCam0.Address));
            return TriggerInvertedCam0.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerInvertedCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedTriggerInvertedCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerInvertedCam0.Address));
            return TriggerInvertedCam0.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerInvertedCam0 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerInvertedCam0Async(byte value)
        {
            var request = TriggerInvertedCam0.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StrobeSourceCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadStrobeSourceCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StrobeSourceCam0.Address));
            return StrobeSourceCam0.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StrobeSourceCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedStrobeSourceCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StrobeSourceCam0.Address));
            return StrobeSourceCam0.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StrobeSourceCam0 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStrobeSourceCam0Async(byte value)
        {
            var request = StrobeSourceCam0.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerFrequencyCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadTriggerFrequencyCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(TriggerFrequencyCam0.Address));
            return TriggerFrequencyCam0.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerFrequencyCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedTriggerFrequencyCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(TriggerFrequencyCam0.Address));
            return TriggerFrequencyCam0.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerFrequencyCam0 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerFrequencyCam0Async(ushort value)
        {
            var request = TriggerFrequencyCam0.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerDurationCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadTriggerDurationCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(TriggerDurationCam0.Address));
            return TriggerDurationCam0.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerDurationCam0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedTriggerDurationCam0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(TriggerDurationCam0.Address));
            return TriggerDurationCam0.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerDurationCam0 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerDurationCam0Async(ushort value)
        {
            var request = TriggerDurationCam0.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerConfigCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadTriggerConfigCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerConfigCam1.Address));
            return TriggerConfigCam1.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerConfigCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedTriggerConfigCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerConfigCam1.Address));
            return TriggerConfigCam1.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerConfigCam1 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerConfigCam1Async(byte value)
        {
            var request = TriggerConfigCam1.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerInvertedCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadTriggerInvertedCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerInvertedCam1.Address));
            return TriggerInvertedCam1.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerInvertedCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedTriggerInvertedCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(TriggerInvertedCam1.Address));
            return TriggerInvertedCam1.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerInvertedCam1 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerInvertedCam1Async(byte value)
        {
            var request = TriggerInvertedCam1.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the StrobeSourceCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadStrobeSourceCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StrobeSourceCam1.Address));
            return StrobeSourceCam1.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the StrobeSourceCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedStrobeSourceCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(StrobeSourceCam1.Address));
            return StrobeSourceCam1.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the StrobeSourceCam1 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteStrobeSourceCam1Async(byte value)
        {
            var request = StrobeSourceCam1.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerFrequencyCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadTriggerFrequencyCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(TriggerFrequencyCam1.Address));
            return TriggerFrequencyCam1.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerFrequencyCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedTriggerFrequencyCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(TriggerFrequencyCam1.Address));
            return TriggerFrequencyCam1.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerFrequencyCam1 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerFrequencyCam1Async(ushort value)
        {
            var request = TriggerFrequencyCam1.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the TriggerDurationCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadTriggerDurationCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(TriggerDurationCam1.Address));
            return TriggerDurationCam1.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the TriggerDurationCam1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedTriggerDurationCam1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(TriggerDurationCam1.Address));
            return TriggerDurationCam1.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the TriggerDurationCam1 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteTriggerDurationCam1Async(ushort value)
        {
            var request = TriggerDurationCam1.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the ConfigureOutput0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadConfigureOutput0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ConfigureOutput0.Address));
            return ConfigureOutput0.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the ConfigureOutput0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedConfigureOutput0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ConfigureOutput0.Address));
            return ConfigureOutput0.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the ConfigureOutput0 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteConfigureOutput0Async(byte value)
        {
            var request = ConfigureOutput0.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the ConfigureOutput1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadConfigureOutput1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ConfigureOutput1.Address));
            return ConfigureOutput1.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the ConfigureOutput1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedConfigureOutput1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(ConfigureOutput1.Address));
            return ConfigureOutput1.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the ConfigureOutput1 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteConfigureOutput1Async(byte value)
        {
            var request = ConfigureOutput1.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OutputSet register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadOutputSetAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutputSet.Address));
            return OutputSet.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OutputSet register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedOutputSetAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutputSet.Address));
            return OutputSet.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the OutputSet register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteOutputSetAsync(byte value)
        {
            var request = OutputSet.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OutputClear register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadOutputClearAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutputClear.Address));
            return OutputClear.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OutputClear register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedOutputClearAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutputClear.Address));
            return OutputClear.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the OutputClear register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteOutputClearAsync(byte value)
        {
            var request = OutputClear.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OutputToggle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadOutputToggleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutputToggle.Address));
            return OutputToggle.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OutputToggle register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedOutputToggleAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutputToggle.Address));
            return OutputToggle.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the OutputToggle register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteOutputToggleAsync(byte value)
        {
            var request = OutputToggle.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the OutputState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadOutputStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutputState.Address));
            return OutputState.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the OutputState register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedOutputStateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(OutputState.Address));
            return OutputState.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the OutputState register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteOutputStateAsync(byte value)
        {
            var request = OutputState.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the DigitalInput register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadDigitalInputAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalInput.Address));
            return DigitalInput.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the DigitalInput register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedDigitalInputAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DigitalInput.Address));
            return DigitalInput.GetTimestampedPayload(reply);
        }
    }
}
