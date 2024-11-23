pipeline {
    agent any

    environment {
        DOTNET_HOME = '/path/to/dotnet'  // Update with your .NET installation path
    }

    stages {
        stage('Checkout') {
            steps {
                // Checkout the source code from Git
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                // Restore NuGet packages
                script {
                    sh 'dotnet restore TaskManagementApp.sln'
                }
            }
        }

        stage('Build') {
            steps {
                // Build the project
                script {
                    sh 'dotnet build TaskManagementApp.sln'
                }
            }
        }

        stage('Test') {
            steps {
                // Run tests
                script {
                    sh 'dotnet test TaskManagementApp.sln'
                }
            }
        }

        stage('Publish') {
            steps {
                // You can publish the artifacts or deploy them here
                echo 'Publishing build artifacts'
            }
        }
    }

    post {
        always {
            // Clean-up actions or sending notifications
            echo 'Cleaning up'
        }

        success {
            // Notify on success
            echo 'Build succeeded'
        }

        failure {
            // Notify on failure
            echo 'Build failed'
        }
    }
}
