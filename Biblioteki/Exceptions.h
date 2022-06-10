#pragma once // jak mam u¿yt¹ biblioteke to nie za³¹cza jej ponownie (oszczednosc pamieci)
#ifndef EXCEPTIONS_H
#define EXCEPTIONS_H

#include <iostream>
#include <exception>

namespace MyExceptions
{
	class FileStreamError : public std::runtime_error
	{
	public:
		FileStreamError() : runtime_error("\n----------\nBlad otwarcia pliku!\n----------\n") {}
		FileStreamError(std::string msg) : runtime_error(msg.c_str()) {}
	};

	class WrongDataInFileError : public std::runtime_error
	{
	public:
		WrongDataInFileError() : runtime_error("\n----------\nBledne dane w pliku z danymi!\n----------\n") {}
		WrongDataInFileError(std::string msg) : runtime_error(msg.c_str()) {}
	};

	class DataError : public std::runtime_error
	{
	public:
		DataError() : runtime_error("\n----------\nBlad danych!\n----------\n") {}
		DataError(std::string msg) : runtime_error(msg.c_str()) {}
	};

	class TooManyTriesError : public std::runtime_error
	{
	public:
		TooManyTriesError() : runtime_error("\n----------\nBlad! Przekroczono liczbe dozwolonych prob!\n----------\n") {}
		TooManyTriesError(std::string msg) : runtime_error(msg.c_str()) {}
	};

	class Error : public std::runtime_error
	{
	public:
		Error() : runtime_error("\n----------\nNiezdefiniowany blad!\n----------\n") {} // przejmujemy konstruktor po klasie runtime_error bo jest on pusty w naszej klasie
		Error(std::string msg) : runtime_error(msg.c_str()) {}
	};
}
#endif
