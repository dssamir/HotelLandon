'use strict'
var gulp = require("gulp");
var sass = require("gulp-sass");

gulp.task("gulp-sass", function () {
    return gulp.src("wwwroot/scss/site.scss")
        .pipe(sass())
        .pipe(gulp.dest("wwwroot/css/"));
});