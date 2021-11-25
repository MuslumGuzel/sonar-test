pipeline {
    agent none

    stages {
		stage ('Clean workspace') {
		  steps {
			cleanWs()
		  }
		}
		stage ('Git Checkout') {
		  steps {
			  git branch: 'master', credentialsId: 'Iv1.dfc743b8e4495c13', url: 'https://github.com/MuslumGuzel/sonar-test'
		  }
      	}
		  
		
        stage('Restore packages') {
		  steps {
			bat "dotnet restore ${workspace}\\<path-to-solution>\\<solution-project-name>.sln"
		  }
		}
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            when {
              expression {
                currentBuild.result == null || currentBuild.result == 'SUCCESS' 
              }
            }
            steps {
                echo "publish ${env.BUILD_ID} on ${env.JENKINS_URL}"
            }
        }
    }
}