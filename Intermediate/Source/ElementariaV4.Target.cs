// Copyright 1998-2016 Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.Collections.Generic;

public class ElementariaV4Target : TargetRules
{
    public ElementariaV4Target(TargetInfo Target)
	{
		Type = TargetType.Game;
	}

	//
	// TargetRules interface.
	//

	public override void SetupBinaries(
		TargetInfo Target,
		ref List<UEBuildBinaryConfiguration> OutBuildBinaryConfigurations,
		ref List<string> OutExtraModuleNames
		)
	{
        OutExtraModuleNames.Add("UE4Game");
		// this is important - for some reason achievements etc intertwined with the onlinesubsystem and they saved without using a fake OSS. :/
		if (Target.Platform == UnrealTargetPlatform.HTML5)
		{
			OutExtraModuleNames.Add("OnlineSubsystemNull");
		}
	}

	public override void SetupGlobalEnvironment(
		TargetInfo Target,
		ref LinkEnvironmentConfiguration OutLinkEnvironmentConfiguration,
		ref CPPEnvironmentConfiguration OutCPPEnvironmentConfiguration
		)
	{
	}
	public override GUBPProjectOptions GUBP_IncludeProjectInPromotedBuild_EditorTypeOnly(UnrealTargetPlatform HostPlatform)
    {
        var Result = new GUBPProjectOptions();
        Result.bTestWithShared = false;
		Result.bIsNonCode = true;
        return Result;
    }

	public override List<UnrealTargetPlatform> GUBP_GetPlatforms_MonolithicOnly(UnrealTargetPlatform HostPlatform)
	{
		List<UnrealTargetPlatform> Platforms = null;

		switch (HostPlatform)
		{
			case UnrealTargetPlatform.Mac:
				Platforms = new List<UnrealTargetPlatform>();
				break;

			case UnrealTargetPlatform.Linux:
				Platforms = new List<UnrealTargetPlatform>();
				break;

			case UnrealTargetPlatform.Win64:
				Platforms = new List<UnrealTargetPlatform>();
				break;

			default:
				Platforms = new List<UnrealTargetPlatform>();
				break;
		}

		return Platforms;
	}

	public override List<UnrealTargetConfiguration> GUBP_GetConfigs_MonolithicOnly(UnrealTargetPlatform HostPlatform, UnrealTargetPlatform Platform)
	{
		return new List<UnrealTargetConfiguration> { UnrealTargetConfiguration.Development, UnrealTargetConfiguration.Shipping, UnrealTargetConfiguration.Test };
	}
	public override List<GUBPFormalBuild> GUBP_GetConfigsForFormalBuilds_MonolithicOnly(UnrealTargetPlatform HostPlatform)
    {
		if (HostPlatform != UnrealTargetPlatform.Mac)
		{
			return new List<GUBPFormalBuild>();			
		}
		else
		{
			return new List<GUBPFormalBuild> 
            { 
                new GUBPFormalBuild(UnrealTargetPlatform.IOS, UnrealTargetConfiguration.Development),
				new GUBPFormalBuild(UnrealTargetPlatform.IOS, UnrealTargetConfiguration.Shipping),
				new GUBPFormalBuild(UnrealTargetPlatform.IOS, UnrealTargetConfiguration.Test, false, true),
            };
		}
	}

}
