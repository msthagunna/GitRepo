import PropTypes from 'prop-types';

const SearchResult =({ result }) =>{
  return (
    <li className="search-result">
      <h3><a href={`#${result.id}`}>{result.name}</a></h3>
      <p>{result.snippet}</p>
    </li>
  );
}
SearchResult.propTypes = {
    result: PropTypes.shape({
      id:PropTypes.number.isRequired,
      name: PropTypes.string.isRequired,
      snippet: PropTypes.string.isRequired
    }).isRequired
  };

export default SearchResult;
