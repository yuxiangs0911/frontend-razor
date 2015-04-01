({
    appDir: '../../html',
    baseUrl: "scripts",
    dir: '../../built',
    mainConfigFile: 'common.js',
    optimizeCss: "standard",
    fileExclusionRegExp: /^(r|build)\.js$/,
    removeCombined: true,
    modules: [
		{
		    name: "common",
		    include: ["base", "api"]
		}
    ]
})