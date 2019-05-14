pipeline {
    agent { dockerfile {
      filename 'Dockerfile.build'
      reuseNode true
    } }

	environment {
        GIT_URL = 'https://github.com/vetronog/Brown_Bears_Life.git'
		UNITY_APP = 'C:\\Program Files\\Unity\\Editor'
		UNITY_PROJECT_PATH = '.\BearLife'
    }
	
    stages {
		stage('Checkout'){
            steps {
				deleteDir()
                git branch: 'master',
					credentialsId: 'ee3f3e84-0371-4fd5-82ad-30f3f0709c98',
					url: GIT_URL
            }
        }
        stage('Build') {
            steps {
                sh 'cd ../Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -nographics -projectPath "$(pwd)" -logFile unitylog.log -executeMethod BuildHandler.Start -quit'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploying....'
            }
        }
    }
	post {
    always {
      deleteDir()
    }
  }
}