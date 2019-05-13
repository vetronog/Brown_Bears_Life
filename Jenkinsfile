pipeline {
    agent any

	environment {
        GIT_URL = 'https://github.com/vetronog/Brown_Bears_Life.git'
    }
	
    stages {
		stage('Git Clone'){
            steps {
                deleteDir()
                slackSend channel: '#chaneel-name', message: "${env.JOB_NAME} is started"
                git branch: 'master', credentialsId: 'Jenkins Master SSH', url: "${GIT_URL}"
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