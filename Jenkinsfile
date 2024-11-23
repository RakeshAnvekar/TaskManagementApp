pipeline {
    agent any
 tools {
        msbuild 'MSBuild 16'  // Adjust this name if you're using a different MSBuild version
    }
    stages {
        stage('Build') {
            steps {
               echo 'Building the ASP.NET solution...'
               script {
                    // Adjust the path to your solution file if necessary
                    def solutionFile = 'TaskManagementApp.sln'
                    
                    // Run MSBuild to build the solution
                    bat "msbuild ${solutionFile} /p:Configuration=Release"
                }
                // Add your build steps here
            }
        }
    }
}
