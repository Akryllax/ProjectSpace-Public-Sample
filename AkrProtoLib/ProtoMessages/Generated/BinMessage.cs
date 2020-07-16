// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ProtoMessages/Templates/binMessage.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from ProtoMessages/Templates/binMessage.proto</summary>
public static partial class BinMessageReflection {

  #region Descriptor
  /// <summary>File descriptor for ProtoMessages/Templates/binMessage.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static BinMessageReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "CihQcm90b01lc3NhZ2VzL1RlbXBsYXRlcy9iaW5NZXNzYWdlLnByb3RvIjAK",
          "CkJpbk1lc3NhZ2USDwoHY29tbWFuZBgBIAEoCRIRCglhcmd1bWVudHMYAiAD",
          "KAliBnByb3RvMw=="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::BinMessage), global::BinMessage.Parser, new[]{ "Command", "Arguments" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class BinMessage : pb::IMessage<BinMessage> {
  private static readonly pb::MessageParser<BinMessage> _parser = new pb::MessageParser<BinMessage>(() => new BinMessage());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pb::MessageParser<BinMessage> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::BinMessageReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public BinMessage() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public BinMessage(BinMessage other) : this() {
    command_ = other.command_;
    arguments_ = other.arguments_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public BinMessage Clone() {
    return new BinMessage(this);
  }

  /// <summary>Field number for the "command" field.</summary>
  public const int CommandFieldNumber = 1;
  private string command_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public string Command {
    get { return command_; }
    set {
      command_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "arguments" field.</summary>
  public const int ArgumentsFieldNumber = 2;
  private static readonly pb::FieldCodec<string> _repeated_arguments_codec
      = pb::FieldCodec.ForString(18);
  private readonly pbc::RepeatedField<string> arguments_ = new pbc::RepeatedField<string>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public pbc::RepeatedField<string> Arguments {
    get { return arguments_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override bool Equals(object other) {
    return Equals(other as BinMessage);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public bool Equals(BinMessage other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Command != other.Command) return false;
    if(!arguments_.Equals(other.arguments_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override int GetHashCode() {
    int hash = 1;
    if (Command.Length != 0) hash ^= Command.GetHashCode();
    hash ^= arguments_.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void WriteTo(pb::CodedOutputStream output) {
    if (Command.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Command);
    }
    arguments_.WriteTo(output, _repeated_arguments_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public int CalculateSize() {
    int size = 0;
    if (Command.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Command);
    }
    size += arguments_.CalculateSize(_repeated_arguments_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(BinMessage other) {
    if (other == null) {
      return;
    }
    if (other.Command.Length != 0) {
      Command = other.Command;
    }
    arguments_.Add(other.arguments_);
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  public void MergeFrom(pb::CodedInputStream input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Command = input.ReadString();
          break;
        }
        case 18: {
          arguments_.AddEntriesFrom(input, _repeated_arguments_codec);
          break;
        }
      }
    }
  }

}

#endregion


#endregion Designer generated code
