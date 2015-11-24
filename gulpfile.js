var gulp = require('gulp');


// ��bower�Ŀ��ļ���Ӧ��ָ��λ��
gulp.task('buildlib',function(){

  gulp.src('./bower_components/art-dialog/dist/dialog-min.js')
      .pipe(gulp.dest('./libs/js/'))

  gulp.src('./bower_components/jquery/dist/jquery.min.js')
      .pipe(gulp.dest('./libs/js/'))
      
  gulp.src('./bower_components/jquery/dist/jquery.min.map')
  .pipe(gulp.dest('./libs/js/'))

  gulp.src('./bower_components/bootstrap/dist/js/bootstrap.min.js')
      .pipe(gulp.dest('./libs/js/'))

  //--------------------------css-------------------------------------
  gulp.src('./bower_components/art-dialog/css/ui-dialog.css')
      .pipe(gulp.dest('./libs/css/'))

  gulp.src('./bower_components/bootstrap/dist/css/bootstrap.min.css')
      .pipe(gulp.dest('./libs/css/'))

  gulp.src('./bower_components/bootstrap/dist/css/bootstrap.css.map')
      .pipe(gulp.dest('./libs/css/'))
});

// ����develop�������ճ�������ʹ��
gulp.task('develop',function(){
  gulp.run('buildlib');
});

// ����һ��prod������Ϊ������������ʱʹ��
gulp.task('prod',function(){
  gulp.run('buildlib','stylesheets','javascripts');
});

// gulp����Ĭ�������ľ���default��Ϊ,���ｫclean������Ϊ����,Ҳ������ִ��һ��clean����,�����ټ���.
gulp.task('default', function() {
  gulp.run('develop');
});