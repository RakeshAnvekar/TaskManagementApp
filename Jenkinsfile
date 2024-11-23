pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building the ASP.NET solution...'
                script {
                    // Adjust the path to your solution file (example here assumes it's in the root)
                    def solutionFile = 'YourSolution.sln'  // or 'src/YourSolution.sln' or 'path/to/yourSolution.sln'

                    // If MSBuild is in the PATH, just use "msbuild" command directly:
                    bat "msbuild ${solutionFile} /p:Configuration=Release"
                    
                    // Alternatively, use the full path to MSBuild if it's not in the PATH:
                    // bat "C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\\BuildTools\\MSBuild\\Current\\Bin\\MSBuild.exe ${solutionFile} /p:Configuration=Release"
                }
            }
        }
    }
}
