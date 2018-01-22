node('master') {
	stage('import') {
		try {
			git 'https://github.com/escalonn/AlertOutside.git'
		}
		catch (exc) {
			slackError('import')
			throw exc
		}
	}
	stage('build') {
		try {
			dir('LocationAlert') {
				bat 'dotnet build --no-incremental'
			}
			dir ('LocationAlert.Angular/Angular') {
				bat 'npm install'
				bat 'ng build'
			}
		}
		catch (exc) {
			slackError('build')
			throw exc
		}
	}
	stage('analyze') {
		try {
			dir('LocationAlert') {
				bat 'SonarQube.Scanner.MSBuild.exe begin /k:ao473840 /n:alertoutside /v:0.2.0'
				bat 'dotnet build --no-incremental'
				bat 'SonarQube.Scanner.MSBuild.exe end'
			}
			// dir('LocationAlert.Angular/Angular') {
			// 	bat 'SonarQube.Scanner.exe /k:ao221662 /n:alertoutsideangular /v:0.1.0'
			// }
		}
		catch (exc) {
			slackError('analyze')
			throw exc
		}
	}
	stage('test') {
		try {
			dir('LocationAlert') {
				dir('LocationAlert.Test') {
					bat 'dotnet test'
				}
				// dir('LocationAlert.Angular/Angular') {
				// 	bat 'ng test'
				// }
			}
		}
		catch (exc) {
			slackError('test')
			throw exc
		}
	}
	stage('package') {
		try {
			dir('LocationAlert') {
				dir('LocationAlert.Client') {
					bat 'dotnet publish --output ../../PackageClient'
				}
				dir('LocationAlert.Library.Service') {
					bat 'dotnet publish --output ../../PackageLibrary'
				}
				dir('LocationAlert.Data.Service') {
					bat 'dotnet publish --output ../../PackageData'
				}
			}
			dir('LocationAlert.Angular/Angular') {
				bat 'ng build --base-href /LocationAlert/'
				bat 'copy /y ..\\..\\web.config dist'
				// ng build inside jenkins workspace doesn't
				bat 'copy /y src\\favicon.ico dist'
				bat 'md dist\\assets\\images'
				bat 'copy /y src\\assets\\images\\*.png dist\\assets\\images'
			}
		}
		catch (exc) {
			slackError('package')
			throw exc
		}
	}
	stage('deploy') {
		try {
			bat "MSDeploy.exe -verb:sync -source:${env.DeploySettings__client_source} -dest:${env.DeploySettings__client_dest} -enableRule:AppOffline -allowUntrusted"
			bat "MSDeploy.exe -verb:sync -source:${env.DeploySettings__library_source} -dest:${env.DeploySettings__library_dest} -enableRule:AppOffline -allowUntrusted"
			bat "MSDeploy.exe -verb:sync -source:${env.DeploySettings__data_source} -dest:${env.DeploySettings__data_dest} -enableRule:AppOffline -allowUntrusted"
			bat "MSDeploy.exe -verb:sync -source:${env.DeploySettings__angular_source} -dest:${env.DeploySettings__angular_dest} -enableRule:AppOffline -allowUntrusted"
		}
		catch (exc) {
			slackError('deploy')
			throw exc
		}
	}
}

def slackError(stageName) {
	slackSend color: 'danger', message: "${stageName} stage failed. [<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString[0..-14]}]"
}
