pipeline {
    agent any

	environment {
        GIT_URL = 'ssh://git@github.com:vetronog/Brown_Bears_Life.git'
    }
	
    stages {
		stage('Git Clone'){
            steps {
                git branch: 'master',
					credentialsId: 'ee3f3e84-0371-4fd5-82ad-30f3f0709c98',
					url: GIT_URL

				sh "ls -lat"
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