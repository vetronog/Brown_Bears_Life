pipeline {
    agent { dockerfile {
      filename 'Dockerfile.build'
      reuseNode true
    } }

	environment {
        GIT_URL = 'https://github.com/vetronog/Brown_Bears_Life.git'
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
                echo 'Building..'
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
}