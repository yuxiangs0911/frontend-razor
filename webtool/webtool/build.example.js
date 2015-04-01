({
    appDir: '../../publish',
    baseUrl: "scripts",
    dir: '../../publish-built',
    mainConfigFile: 'common.js',
    optimizeCss: "standard",
    fileExclusionRegExp: /^(r|build)\.js$/,
    removeCombined: true,
    keepBuildDir: true,
    modules: [
		{
		    name: "common",
		    include: ["base", "api"]
		},
        {
            name: "app/infocenter",
            exclude: ["common"]
        }
    ]
})