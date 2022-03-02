﻿namespace ErsatzTV.FFmpeg.Decoder.Cuvid;

public class DecoderH264Cuvid : DecoderBase
{
    public override string Name => "h264_cuvid";

    public override IList<string> InputOptions(InputFile inputFile)
    {
        IList<string> result = base.InputOptions(inputFile);

        result.Add("-hwaccel_output_format");
        result.Add("cuda");

        return result;
    }

    protected override FrameDataLocation OutputFrameDataLocation => FrameDataLocation.Hardware;
}