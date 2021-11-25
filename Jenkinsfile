import hudson.tasks.test.AbstractTestResultAction
import groovy.json.JsonSlurper

node {
	stage 'Clean WorkSpace'
		cleanWs()
		
	stage ('Git Checkout') {
		git branch: 'master', credentialsId: 'Iv1.dfc743b8e4495c13', url: 'https://github.com/MuslumGuzel/sonar-test'
	}
	stage 'Build'
		dir('SonarTest') {
			sh(script: 'dotnet build SonarTest.csproj', returnStdout: true);		
		}
	stage 'UnitTests'
		dir('SonarTest.Test') {
		
		sh(script: 'dotnet restore', returnStdout: true);
		sh(script: 'dotnet xunit -xml xunit-results.xml', returnStdout: true);
    }
		
}

