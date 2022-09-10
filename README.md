# About

Uses the [CliWrap library](https://github.com/Tyrrrz/CliWrap) to execute the external `virsh vol-list` application to get the latest libvirt volume that has the `ubuntu-20.04-amd64_vagrant_box_image_0_` prefix.

# Usage

Install the dotnet-sdk 6.0.

Run:

```bash
dotnet run
```

You should see something like:

```plain
ubuntu-20.04-amd64_vagrant_box_image_0_1661689571_box.img
```
