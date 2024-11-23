pipeline {
    agent {
        label 'windows'
    }
    stages {
        stage('Build') {
            steps {
                bat 'dotnet restore TaskManagementApp.sln'
            }
        }
        stage('Test') {
            steps {
                bat 'dotnet test TaskManagementApp.sln'
            }
        }
    }
}
