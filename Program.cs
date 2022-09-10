using CliWrap;
using CliWrap.Buffered;

var baseVolumeName = await GetBaseVolumeName();

Console.WriteLine(baseVolumeName);

static async Task<string> GetBaseVolumeName()
{
    var result = await Cli.Wrap("virsh")
        .WithArguments(new[] {"vol-list", "--pool", "default"})
        .ExecuteBufferedAsync();
    // e.g.:
    //   Name                                                        Path
    //  ------------------------------------------------------------------------------------------------------------------------------------------------
    //   ubuntu-20.04-amd64_vagrant_box_image_0_1661689571_box.img   /var/lib/libvirt/images/ubuntu-20.04-amd64_vagrant_box_image_0_1661689571_box.img
    return result.StandardOutput
        .Split(Environment.NewLine)
        .Select(line => line.Trim().Split(" ", 2).FirstOrDefault(""))
        .Where(name => name.StartsWith("ubuntu-20.04-amd64_vagrant_box_image_"))
        .OrderByDescending(name => name)
        .First();
}
