import hudson.tasks.test.AbstractTestResultAction
  
node {
	stage 'Clean WorkSpace'
		cleanWs()
		
	stage ('Git Checkout') {
		git branch: 'master', credentialsId: 'Iv1.dfc743b8e4495c13', url: 'https://github.com/MuslumGuzel/sonar-test'
	}
	stage 'Build'
		bat "nuget restore \"${workspace}/SonarTest.sln\""
		bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/SonarTest.sln\""
		bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/SonarTest.sln\""

	stage 'UnitTests'
		bat returnStatus: true, script: "\"C:/Program Files/dotnet/dotnet.exe\" test \"${workspace}/SonarTest.sln\" --logger \"trx;LogFileName=unit_tests.xml\" --no-build"
		step([$class: 'MSTestPublisher', testResultsFile:"**/unit_tests.xml", failOnError: true, keepLongStdio: true])
		
}